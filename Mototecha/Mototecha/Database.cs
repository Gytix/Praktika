using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mototecha
{
    class Database
    {
        public MySqlConnection myDatabase;
        public Database()
        {
            myDatabase = new MySqlConnection("Data Source=localhost;Initial Catalog=praktikai;User ID=root;Password=");

        }
        public void Open()
        {
            if (myDatabase.State != System.Data.ConnectionState.Open)
            {
                myDatabase.Open();
            }
        }

        public void Close()
        {
            if (myDatabase.State != System.Data.ConnectionState.Closed)
            {
                myDatabase.Close();
            }
        }

    }

}
