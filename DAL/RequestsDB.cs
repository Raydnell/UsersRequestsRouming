using UsersRequestsRouming.Models;
using Microsoft.EntityFrameworkCore;

namespace UsersRequestsRouming.DAL
{ 
    public class RequestsDB : DbContext
    {
        public DbSet<Request> Requests { get; set; }

        public RequestsDB()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=i102615484\\SQLEXPRESS;Database=UsersRequests;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}