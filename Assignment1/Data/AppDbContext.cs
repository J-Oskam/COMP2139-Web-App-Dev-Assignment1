using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }
        public DbSet<Bookings> Bookings { get; set; }
    }
}
