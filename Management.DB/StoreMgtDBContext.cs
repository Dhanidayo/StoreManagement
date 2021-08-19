using Microsoft.EntityFrameworkCore;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.DB
{
    public class StoreMgtDbContext : DbContext
    {
        //the Code-first method
        //using EF Core to create customers and stores table
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer
                (@"Data Source= .;Initial Catalog= StoreManagementApp;Integrated Security=True");
        }
    }
}