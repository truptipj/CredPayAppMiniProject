using CredAppMiniProject.Entities;
using CredAppMiniProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CredAppMiniProject.Data
{
    public class CredPayAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public CredPayAppDbContext(DbContextOptions<CredPayAppDbContext> options) : base(options)
        {
        }
       //protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
            //modelBuilder.Entity<Pay>()
            //    .HasMany(c => c.CardDetail)
            //    .WithOne(e => e.Pay);

            //builder.Entity<Transaction>().
            //    HasOne(x => x.Account).WithMany(x => x.Transactions).HasForeignKey(x => x.AccountNumber);
            //builder.Entity<Transaction>().HasCheckConstraint("CH_Transaction_Amount", "Amount > 0");

            //builder.Entity<PaymentDetail>().
            //    HasOne(x => x.Account).WithMany(x => x.BillPays).HasForeignKey(x => x.AccountNumber);
            //builder.Entity<BillPay>().
            //    HasOne(x => x.Payee).WithMany(x => x.BillPays).HasForeignKey(x => x.PayeeID);
            //modelBuilder.Entity<CardDetail>()
            //    .HasMany(c => c.Pay)
            //    .WithOne(p => p.CardDetail);

            // }

        public DbSet<CardDetail> CardDetails{ get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Pay> Pay { get; set; }
    }

}
