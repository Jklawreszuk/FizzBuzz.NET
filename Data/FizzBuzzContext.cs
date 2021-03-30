using Microsoft.EntityFrameworkCore;
using FizzBuzzNET.Models;

namespace FizzBuzzNET.Data
{
    public class FizzBuzzContext : DbContext
    {
        DbSet<FizzBuzz> FizzBuzzes {get;set;}

        //Fluent API - inkrementacja id
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<FizzBuzz>().Property(p=>p.ID).ValueGeneratedOnAdd();
        }
    }
}