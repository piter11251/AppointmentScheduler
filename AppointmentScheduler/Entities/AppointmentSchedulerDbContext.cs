using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Entities
{
    public class AppointmentSchedulerDbContext: DbContext
    {
        public AppointmentSchedulerDbContext(DbContextOptions<AppointmentSchedulerDbContext> options) : base(options)
        {

        }
        private string _connectionString = "Data Source=DESKTOP-6RCKR67;Initial Catalog=AppointmentDb;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Title)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentDate)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Appointments)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
