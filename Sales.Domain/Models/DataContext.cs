﻿namespace Sales.Domain.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public DbSet<Common.Models.Products> Products { get; set; }

        public DbSet<Common.Models.Category> Categories { get; set; }
    }
}
