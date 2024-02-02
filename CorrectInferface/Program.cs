using System;
using System.Windows.Forms;

namespace CorrectInferface
{
    public class ConnectString
    {
        public static string connectionString;
        public static string login;
    }
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
