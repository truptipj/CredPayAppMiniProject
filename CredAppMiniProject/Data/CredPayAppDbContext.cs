using CredAppMiniProject.Entities;
using CredAppMiniProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Data
{
    public class CredPayAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public CredPayAppDbContext(DbContextOptions<CredPayAppDbContext> options) : base(options)
        {
        }

        //Relationships
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Transaction>().
        //        HasOne(x => x.AddCards).WithMany(x => x.Transactions).HasForeignKey(x => x.AccountNumber);
        //    builder.Entity<Transaction>().HasCheckConstraint("CH_Transaction_Amount", "Amount > 0");

        //    builder.Entity<BillPay>().
        //            HasOne(x => x.AddCard).WithMany(x => x.BillPays).HasForeignKey(x => x.AccountNumber);
        //    builder.Entity<BillPay>().
        //            HasOne(x => x.Payee).WithMany(x => x.BillPays).HasForeignKey(x => x.PayeeID);
        //}


        public DbSet<CardDetail> CardDetails{ get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Pay> Pay { get; set; }
    }

}
