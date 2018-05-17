using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopShortcutMgr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }


        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Application.ThreadException -= new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
            AppDomain.CurrentDomain.UnhandledException -= new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject != null && e.ExceptionObject is Exception)
            {
                HandleError((Exception)e.ExceptionObject);
            }
            else if (e.ExceptionObject != null)
            {
                MessageBox.Show(string.Format("Unexpected error: {0}", e.ExceptionObject));
            }
            else
            {
                 MessageBox.Show(string.Format("Unexpected error. No Exception Object found"));
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleError(e.Exception);
        }

        public static void HandleError(Exception ex)
        {
            CrashReporterLibrary.CrashReporter crashRpt = new CrashReporterLibrary.CrashReporter(ex);
            crashRpt.ShowDialog();
        }

    }
}
