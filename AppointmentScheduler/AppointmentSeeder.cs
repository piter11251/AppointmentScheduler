using AppointmentScheduler.Entities;

namespace AppointmentScheduler
{
    public class AppointmentSeeder
    {
        private readonly AppointmentSchedulerDbContext _dbContext;
        public AppointmentSeeder(AppointmentSchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var user = new User()
                    {
                        Email = "99.pkozlowski@gmail.com",
                        Password = "password",
                        FirstName = "Piotr",
                        LastName = "Kozlowski"
                    };

                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Appointments.Any())
                {
                    var user = _dbContext.Users.First();
                    var appointments = GetAppointments(user);
                    _dbContext.Appointments.AddRange(appointments);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Appointment> GetAppointments(User user)
        {
            var appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    Title = "Daily with IT Team",
                    Description = "What have I done yesterday and what I will do today",
                    AppointmentDate = new DateTime(2024, 7, 31, 11, 0, 0),
                    UserId = user.Id,
                    User = user
                },
                new Appointment()
                {
                    Title = "Meet with Finance Director",
                    Description = "Super important",
                    AppointmentDate = new DateTime(2024, 8, 1, 12, 0, 0),
                    UserId = user.Id,
                    User = user
                },
                new Appointment()
                {
                    Title = "Fast meet",
                    AppointmentDate = new DateTime(2024, 7, 30, 13, 25, 0),
                    UserId = user.Id,
                    User = user
                }
            };
            return appointments;
        }
    }
}
