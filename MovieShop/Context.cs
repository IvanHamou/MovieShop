﻿using Microsoft.EntityFrameworkCore;
using System;

namespace DatabaseConnection
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"server=.;" +
                @"database=SaleDatabase;" +
                @"trusted_connection=true;" +
                @"MultipleActiveResultSets=True"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
