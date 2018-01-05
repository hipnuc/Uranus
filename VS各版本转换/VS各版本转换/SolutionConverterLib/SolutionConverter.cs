namespace SolutionConverterLib
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Converts from one Visual Studio solution version to another.
    /// </summary>
    public class SolutionConverter : IConverter
    {
        /// <summary>
        /// The path to the solution file.
        /// </summary>
        private string solutionPath;

        /// <summary>
        /// Lists all the conversion status of every project.
        /// </summary>
        private List<ConversionResult> projectConversionResults;

        /// <summary>
        /// Regular expression representing the format that project files are
        /// listed in the solution file.
        /// </summary>
        private readonly Regex projectPathRegex = new Regex(@"Project.*,*,", RegexOptions.Compiled);

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionConverter"/> class.
        /// </summary>
        /// <param name="solutionPath">The path to the solution file.</param>
        public SolutionConverter(string solutionPath)
        {
            this.projectConversionResults = new List<ConversionResult>();
            this.Load(solutionPath);

        }

        /// <summary>
        /// Gets or sets the solution version.
        /// </summary>
        /// <value>The solution version.</value>
        public VisualStudioVersion VisualStudioVersion { get; protected set; }

        /// <summary>
        /// Gets or sets the IDE version.
        /// </summary>
        /// <value>The IDE version.</value>
        public IdeVersion IdeVersion { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is ready.
        /// </summary>
        /// <value><c>true</c> if this instance is ready; otherwise, <c>false</c>.</value>
        public bool IsReady { get; protected set; }

        /// <summary>
        /// Gets the name of the solution or project the converter is working on.
        /// </summary>
        /// <value>The name of the solution or project.</value>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the project conversion results.
        /// </summary>
        /// <value>The project conversion results.</value>
        public List<ConversionResult> ProjectConversionResults
        {
            get { return projectConversionResults; }
        }

        /// <summary>
        /// Loads the solution.
        /// </summary>
        /// <param name="solutionPath">The solution path.</param>
        /// <returns><c>true</c> if successful; <c>false</c> otherwise.</returns>
        public bool Load(string solutionPath)
        {
            if (solutionPath == null)
            {
                throw new Exception("solutionPath can't be null");
            }

            this.solutionPath = solutionPath;
            return this.Reload();
        }

        /// <summary>
        /// Reloads the current solution.
        /// </summary>
        /// <returns><c>true</c> if successful; <c>false</c> otherwise.</returns>
        public bool Reload()
        {
            this.VisualStudioVersion = this.GetSolutionVersion();
            this.IdeVersion = this.GetIdeVersion();
            this.Name = Path.GetFileNameWithoutExtension(this.solutionPath);
            if (this.VisualStudioVersion != VisualStudioVersion.Unknown)
            {
                this.IsReady = true;
            }
            else
            {
                this.IsReady = false;
            }

            return this.IsReady;
        }

        /// <summary>
        /// Converts to the specified <paramref name="solutionVersion"/>.
        /// </summary>
        /// <param name="solutionVersion">The solution version.</param>
        /// <returns><c>true</c> if successful; <c>false</c> otherwise.</returns>
        public ConversionResult ConvertTo(VisualStudioVersion solutionVersion)
        {
            return this.ConvertTo(solutionVersion, IdeVersion.Default);
        }

        /// <summary>
        /// Converts to the specified <paramref name="solutionVersion"/>.
        /// </summary>
        /// <param name="solutionVersion">The solution version.</param>
        /// <param name="ideVersion">The IDE version.</param>
        /// <returns><c>true</c> if successful; <c>false</c> otherwise.</returns>
        public ConversionResult ConvertTo(VisualStudioVersion solutionVersion, IdeVersion ideVersion)
        {
            ConversionResult result = new ConversionResult();
            result.ConverterReference = this;
            if (!this.IsReady)
            {
                result.ConversionStatus = ConversionStatus.NotReady;
                return result;
            }

            bool success = true;
            StreamReader reader = new StreamReader(this.solutionPath);
            FileStream stream = null;
            TextWriter writer = null;
            string sln = reader.ReadToEnd();
            reader.Close();

            // Replace the solution version.
            sln = sln.Replace(this.VisualStudioVersion.GetStringValue(), solutionVersion.GetStringValue());

            // If possible, also update the Ide version as well.
            if (ideVersion != IdeVersion.Default && this.IdeVersion != IdeVersion.Default)
            {
                string oldVersion, newVersion;
                oldVersion = this.IdeVersion.GetStringValue() + " " + ((int)this.VisualStudioVersion).ToString();
                newVersion = ideVersion.GetStringValue() + " " + ((int)solutionVersion).ToString();
                sln = sln.Replace(oldVersion, newVersion);
            }

            // Now write the file back to the hard drive.
            try
            {
                stream = File.OpenWrite(this.solutionPath);
                writer = new StreamWriter(stream, Encoding.UTF8);
                writer.Write(sln);
            }
            catch (Exception)
            {
                success = false;
            }
            finally
            {
                this.IsReady = false;
                if (stream != null)
                {
                    writer.Close();
                }
            }

            result.ConversionStatus = ConversionStatus.Failed;
            result.ConverterReference = this;
            if (success)
            {
                this.ConvertProjects(solutionVersion);
                result.ConversionStatus = ConversionStatus.Succeeded;
                if (this.projectConversionResults != null)
                {
                    foreach (ConversionResult ret in this.projectConversionResults)
                    {
                        if (ret.ConversionStatus != ConversionStatus.Succeeded)
                        {
                            result.ConversionStatus = ConversionStatus.Partial;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieves the solution version from the file.
        /// </summary>
        /// <returns>Returns the Solution version of the file we're working with.</returns>
        protected VisualStudioVersion GetSolutionVersion()
        {
            VisualStudioVersion solVer = VisualStudioVersion.Unknown;
            TextReader reader = new StreamReader(this.solutionPath);
            string sln = reader.ReadToEnd();
            reader.Close();

            // Here we loop through the possible visual studio versions. 
            // Trying to determine the version of our solution.
            foreach (VisualStudioVersion version in Enum.GetValues(typeof(VisualStudioVersion)))
            {
                string vs = version.ToString();
                if (sln.Replace(" ", "").Contains(version.ToString()) && sln.Contains(version.GetStringValue()))
                {
                    solVer = version;
                    break;
                }
                else if (sln.Contains(version.GetStringValue()))
                {
                    solVer = version;
                }
            }
            return solVer;
        }

        /// <summary>
        /// Gets the IDE version.
        /// </summary>
        /// <returns>Returns the IDE version of the file we're working with.</returns>
        protected IdeVersion GetIdeVersion()
        {
            IdeVersion ideVer = IdeVersion.Default;
            TextReader reader = new StreamReader(this.solutionPath);
            string sln = reader.ReadToEnd();
            reader.Close();

            // Here we loop through the possible visual studio versions. 
            // Trying to determine the IDE version.
            foreach (IdeVersion version in Enum.GetValues(typeof(IdeVersion)))
            {
                if (sln.Contains(version.GetStringValue()))
                {
                    ideVer = version;
                }
            }

            return ideVer;
        }

        /// <summary>
        /// Converts the projects.
        /// </summary>
        /// <param name="solutionVersion">The solution version.</param>
        private void ConvertProjects(VisualStudioVersion solutionVersion)
        {
            using (StreamReader reader = File.OpenText(this.solutionPath))
            {
                List<string> projectStrings = new List<string>();
                IConverter projectConverter;
                string projectName, path;
                int index;

                // A bit messy, but gets the job done.
                // Retrieve the actual path of the solution.
                path = this.solutionPath.Remove(this.solutionPath.IndexOf(Path.GetFileName(this.solutionPath)), Path.GetFileName(this.solutionPath).Length);
                this.projectConversionResults.Clear();

                // Selects all the strings that contain the "Project("{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}") = "Name", "Name\Name.xxproj","
                // signature.
                projectStrings.AddRange(from Match match in this.projectPathRegex.Matches(reader.ReadToEnd())
                                        where match.Success
                                        select match.Value);

                // Here we attempt to convert all the projects and save the conversion results.
                foreach (string projectString in projectStrings)
                {
                    // Cut string down to only contain the solution relative path.
                    projectName = projectString.TrimEnd(new char[] { ' ', ',', '\"' });
                    index = projectName.LastIndexOf('\"') + 1;
                    projectName = path + projectName.Substring(index, projectName.Length - index);
                    projectConverter = null;

                    // Make sure we don't crash the program by trying to convert a Visual C++ project
                    if (!Path.GetExtension(projectName).Contains("vc"))
                    {
                        projectConverter = new ProjectConverter(projectName);
                    }
                    else
                    {
                        // Reserved for a Visual C++ Project converter here.
                    }

                    if (projectConverter != null)
                    {
                        this.projectConversionResults.Add(projectConverter.ConvertTo(solutionVersion));
                    }
                }
            }
        }
    }
}
