using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.Database
{
    internal class DBCon
    {
        public SQLiteConnection DbConnection()
        {
            
            try
            {
                var builder = new SQLiteConnectionStringBuilder();
                string folder = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(folder, "store.db");
                builder.DataSource = path;

                var connection = new SQLiteConnection(builder.ConnectionString);
                connection.Open();
                return connection;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
            

        }

        public void DBClose(SQLiteConnection con)
        {
            con.Close();
            con.Dispose();
        }
    }
}
