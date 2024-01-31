using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvorecKulturi
{
    internal class Settings
    {
        public static class SQLConnected
        {
            static string sqlconnect;
            static string DefaultSqlConnect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MainDatabase.mdf;Integrated Security=True";

            public static string GetSQLConnect()
            {
                if(sqlconnect != null)
                {
                    return sqlconnect;
                }
                else
                {
                    return DefaultSqlConnect;
                }
                
            }

            public static void CheckSQLconnected()
            {

            }

            public static void UpdateSQLconnect(string NewSQLconnect)
            {
                if (NewSQLconnect != null)
                {
                    sqlconnect = NewSQLconnect;
                }
                else
                {

                }
            }
        }
    }
}
