using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace Uranus.Utilities
{
    class CsvFileWriter
    {
        /// <summary>
        /// File path of CSV file.
        /// </summary>
        public string FilePath { get;  set; }

        /// File path of CSV file.
        /// </summary>
        public int Row { get; private set; }
        public int Col { get; private set; }

        /// <summary>
        /// Internal flag used to disable writes during file close.
        /// </summary>
        private bool writesEnabled = false;

        /// <summary>
        /// Stream Writer to write to file.
        /// </summary>
        private StreamWriter streamWriter;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="filePath"></param>
        public CsvFileWriter(string filePath)
        {
            FilePath = filePath;
        }

        public void Start()
        {
            Row = 0;
            Col = 0;
            streamWriter = new System.IO.StreamWriter(FilePath, false);
            writesEnabled = true;
        }

        /// <summary>
        /// Close CSV file.
        /// </summary>
        public void Stop()
        {
            //List<string> fileNames = new List<string>();
            writesEnabled = false;
            if (streamWriter != null)
            {
                streamWriter.Close();
            }
            Row = 0;
            Col = 0;
        }

        /// <summary>
        /// Write array of values as line of CSVs in file.
        /// </summary>
        /// <param name="values"></param>
        public void WriteCSVline(string[] values)
        {
            Row++;
            Col = values.Length;
            if (writesEnabled)
            {

                // Write line
                string csvLine = "";
                for (int i = 0; i < values.Length; i++)
                {
                    csvLine += values[i].ToString(CultureInfo.InvariantCulture);
                    if (i < values.Length - 1)
                    {
                        csvLine += ",";
                    }
                }
                streamWriter.WriteLine(csvLine);
            }
        }
    }
}
