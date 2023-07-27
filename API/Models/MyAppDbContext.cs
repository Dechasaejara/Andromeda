using API.Models.TourAddis;
using Microsoft.EntityFrameworkCore;
namespace API.Models.Dereja;
public class MyAppDbContext : DbContext // IdentityDbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
    {
        //  Parameter values pass when instance of Db context created through DI
    }
    // DB Tables
    // public virtual DbSet<User> Users { get; set; }
    // public DbSet<Customer> Customers { get; set; }
    #region Tour Addis
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourBooking> TourBookings { get; set; }
        public DbSet<TourReview> TourReviews { get; set; }
    #endregion
    #region Dereja
        public DbSet<DetailNote> DetailNotes { get; set; }
        public DbSet<AppConstant> AppConstants { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CheatSheet> CheatSheets { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Solution> Solutions { get; set; }
    #endregion
}
