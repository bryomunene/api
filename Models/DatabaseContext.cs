using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace web_api.Models
{
    public class DatabaseContext : DbContext
    {
        public MySqlConnection Connection;

        public void Dispose()
        {
            Connection.Close();
        }

        public DbSet ProductCategory { get; set; }
        public string ConnectionString { get; set; }

        public DatabaseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public  DatabaseContext() : base("DefaultConnection") //Connection string name write here  
        { }  

    }
}
