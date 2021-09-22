using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using web_api.Models;


namespace web_api.Models
{
    [BindProperties(SupportsGet = true)]
    public class Product : DbContext
    {
        public DatabaseContext context;

        [Key]
        [Required]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product Name")]

        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Description")]

        public string ProductDescription { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        [Range(0, 9999999999999999.99)]
        public decimal ProductPrice { get; set; }

        [Required]
        [Display(Name = "Product Quantity")]

        public int ProductQuantity { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }

    }
}
