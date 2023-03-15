using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ts_kita
{
    public class DataBase : DbContext
    {
        public static string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        // private SqliteConnection connection = new SqliteConnection(@"Data Source=" +
        //                                                            DataBase.strExeFilePath.Substring(0,
        //                                                                strExeFilePath.Length - 10) +
        //                                                            @"\db.sqlite");
        private SqliteConnection connection = new SqliteConnection(@"Data Source=C:\Users\kak7\Documents\GitHub\ts_kita\db.sqlite");

        public DataBase()
        {
            Console.WriteLine(connection);
            connection.Open();
        }

        public SqliteDataReader GetReader(string cmdText)
        {
            var command = connection.CreateCommand();
            command.CommandText = cmdText;

            return command.ExecuteReader();
        }

        public void ExecuteNonQuery(string cmdText)
        {
            var command = connection.CreateCommand();
            command.CommandText = cmdText;
            command.ExecuteNonQuery();
        }
    }
}