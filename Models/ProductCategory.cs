using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web_api.Models;


namespace web_api.Models
{
    [BindProperties(SupportsGet = true)]
    public class ProductCategory 
    {
        public DatabaseContext context;

        [Key]
        [Required]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Category Description")]

        public string CategoryDescription { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
