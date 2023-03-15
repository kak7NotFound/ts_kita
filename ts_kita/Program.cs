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

            /*using (var reader = Program.database.GetReader("select * from requests"))
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
            Program.database.ExecuteNonQuery($"insert into requests values ('выф', 'фвыв', 'ывыв', 'фыва', 0, 'фываа', 'вывы')");*/
            Console.WriteLine(GetNow());
            Application.Run(new Form1());

        }

        public static String GetNow()
        {
            return DateTime.Now.ToString("u").Substring(0, 19);
        }

    }
}