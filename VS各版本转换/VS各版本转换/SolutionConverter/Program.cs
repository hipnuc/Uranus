namespace SolutionConverter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// The main class which holds the program's entry point method.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                Application.Run(new FrmMain(args[0]));
            }
            else
            {
                Application.Run(new FrmMain());
            }
        }
    }
}
