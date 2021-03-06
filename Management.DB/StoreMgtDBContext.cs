using Microsoft.EntityFrameworkCore;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.DB
{
    public class StoreMgtDBContext : DbContext
    {
        //the Code-first method
        //using EF Core to create customers, stores, and products table
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer
                (@"Data Source= .;Initial Catalog= StoreManagementApp;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Fluent API for primary key
            builder.Entity<Customer>()
                    .HasKey(Customer => Customer.Id);

            builder.Entity<Products>()
                    .HasKey(Products => Products.Id);

            //Fluent API for properties
            builder.Entity<Customer>()
                    .Property(customer => customer.Email)
                    .IsRequired();

            builder.Entity<Customer>()
                    .Ignore(customer => customer.FullName);


            //Fluent API for One to Many relationship
            //In this case, a customer has many stores.
            builder.Entity<Customer>()
                    .HasMany(customer => customer.stores)
                    .WithOne(Store => Store.Customer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(customer => customer.UserId)
                    .IsRequired();

            //One to Many relationship between store and product
            //In this case, a store has many products
            builder.Entity<Store>()
                    .HasMany(store => store.Products)
                    .WithOne(Products => Products.Store)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(products => products.StoreId)
                    .IsRequired();
        }
    }
}