using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Models
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //public MySqlConnection Connection;

        public DatabaseContext(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<ProductCategory> productcategory { get; set; }

    }
}
