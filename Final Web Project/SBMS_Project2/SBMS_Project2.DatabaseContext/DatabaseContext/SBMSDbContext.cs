﻿using SBMS_Project2.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.DatabaseContext.DatabaseContext
{
    public class SBMSDbContext:DbContext
    {
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseSupplier> PurchaseSuppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<CustomerSale> CustomerSales { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }







        //public Category FirstOrDefault()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
