using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopShortcutMgr
{
    /// <summary>
    /// The main entry point for the application.
    /// Handles application-level initialization and global error handling.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments (not used).</param>
        [STAThread]
        static void Main(string[] args)
        {
...
        }

        /// <summary>
        /// Handles the application exit event, ensuring all global exception handlers are unhooked.
        /// </summary>
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Application.ThreadException -= new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
            AppDomain.CurrentDomain.UnhandledException -= new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        /// <summary>
        /// Global handler for unhandled exceptions within the current application domain.
        /// </summary>
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

        /// <summary>
        /// Global handler for unhandled UI thread exceptions.
        /// </summary>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleError(e.Exception);
        }

        /// <summary>
        /// Displays a crash reporter form for the specified exception.
        /// </summary>
        /// <param name="ex">The exception that occurred.</param>
        public static void HandleError(Exception ex)
        {
			Forms.CrashReporterForm crashRpt = new Forms.CrashReporterForm(ex);
            crashRpt.ShowDialog();
        }

    }
}
