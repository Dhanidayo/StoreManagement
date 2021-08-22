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

            //Fluent API for properties
            builder.Entity<Customer>()
                    .Property(customer => customer.Email)
                    .IsRequired();

            builder.Entity<Customer>()
                    .Ignore(customer => customer.FullName);

            //Fluent API for One to Many relationship
            //In this case, a customer has many stores.
            builder.Entity<Customer>()
                    .HasMany(customer => customer.Stores)
                    .WithOne(Store => Store.Customer)
                    .OnDelete(DeleteBehaviour.Cascade)
                    .HasForeignKey(customer => customer.UserId)
                    .IsRequired();

            //One to Many relationship between store and product
            //In this case, a store has many products
            builder.Entity<Store>()
                    .HasMany(store => store.Products)
                    .WithOne(Product => Product.Store)
                    .OnDelete(DeleteBehaviour.Cascade)
                    .HasForeignKey(product => product.StoreId)
                    .IsRequired();
        }
    }
}