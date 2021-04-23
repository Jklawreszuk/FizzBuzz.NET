using Microsoft.EntityFrameworkCore;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FizzBuzzNET.Data
{
    public class FizzBuzzContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<FizzBuzzRecord> FizzBuzzRecords {get;set;}
        public FizzBuzzContext(DbContextOptions opt):base(opt){}
        //Fluent API - inkrementacja id
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FizzBuzzRecord>().Property(p=>p.ID).ValueGeneratedOnAdd();
        }
    }
}