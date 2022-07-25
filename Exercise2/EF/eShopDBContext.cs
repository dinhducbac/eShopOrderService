
using eShopOrderService.Configuration;
using eShopOrderService.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Exercise2.EF
{
    public class eShopDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.Seed();
           // base.OnModelCreating(builder);
           
        }
        public eShopDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
    }
}
