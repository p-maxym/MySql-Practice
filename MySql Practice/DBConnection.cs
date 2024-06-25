using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace MySql_Practice
{
    class DBConnection
    {
        static readonly string DBConnect = "server=localhost;user=root;password=Parolotmysql1@;" +
            "database=taskmanagerdb";
        public static MySqlDataAdapter? msDataAdapter;
        static MySqlConnection? myConnect;
        static public MySqlCommand? msCommand;

        public static bool ConnectionDB()
        {
            try
            {
                myConnect = new MySqlConnection(DBConnect);
                myConnect.Open();
                msCommand = new MySqlCommand { Connection =  myConnect };
                msDataAdapter = new MySqlDataAdapter(msCommand);
                return true;
            }
            catch
            {
                MessageBox.Show("Database connection error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static void CloseDB()
        {
            try { myConnect?.Close(); }
            catch { MessageBox.Show("Closing the database failed!"); }
        }

        public MySqlConnection getConnection()
        {
            if (myConnect == null) throw new InvalidOperationException("Database connection is not initialized.");
            return myConnect;
        }
    }
}
