using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace ts_kita
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

        private const int ATTACH_PARENT_PROCESS = -1;

        public static DataBase database;


        [STAThread]
        static void Main(string[] args)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine(GetNow());
            Application.Run(new LoginForm());

        }

        public static String GetNow()
        {
            return DateTime.Now.ToString("u").Substring(0, 19);
        }

    }
}