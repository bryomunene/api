using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using web_api.Models;

namespace web_api.Models
{
    public class ProductCategory : DatabaseContext
    {
        public DatabaseContext context;

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryDescription { get; set; }

        public List<ProductCategory> GetAllProductCategories()
        {
            List<ProductCategory> list = new List<ProductCategory>();

            using (MySqlConnection conn = context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from web_api.productcategory", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ProductCategory()
                        {
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            CategoryName = reader["CategoryName"].ToString(),
                            CategoryDescription = reader["CategoryDescription"].ToString()
                            //Price = Convert.ToInt32(reader["Price"]),
                            //Genre = reader["genre"].ToString()
                        });
                    }
                }
            }
            return list;
        }

    }
}
