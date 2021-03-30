using Microsoft.EntityFrameworkCore;
using FizzBuzzNET.Models;

namespace FizzBuzzNET.Data
{
    public class FizzBuzzContext : DbContext
    {
        DbSet<FizzBuzzRecord> FizzBuzzRecords {get;set;}
        public FizzBuzzContext(DbContextOptions opt):base(opt){}
        //Fluent API - inkrementacja id
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<FizzBuzzRecord>().Property(p=>p.ID).ValueGeneratedOnAdd();
        }
    }
}