using Microsoft.EntityFrameworkCore;

namespace RSVP
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<HotelReservation> HotelReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(c => c.HotelReservations)
                .WithOne(d => d.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(p => p.No)
                .ValueGeneratedOnAdd();


        }

    }
}
