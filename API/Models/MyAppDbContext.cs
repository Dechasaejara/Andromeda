using Microsoft.EntityFrameworkCore;
namespace API.Models;

public class MyAppDbContext : DbContext // IdentityDbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
    {
        //  Parameter values pass when instance of Db context created through DI
    }
    // DB Tables
    // public virtual DbSet<User> Users { get; set; }
    // public DbSet<Customer> Customers { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<TourBooking> tourBookings { get; set; }
    public DbSet<TourReview> tourReviews { get; set; }
}
