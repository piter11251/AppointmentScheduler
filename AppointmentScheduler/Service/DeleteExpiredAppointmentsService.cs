using AppointmentScheduler.Entities;

namespace AppointmentScheduler.Service
{
    public class DeleteExpiredAppointmentsService: IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer _timer;

        public DeleteExpiredAppointmentsService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppointmentSchedulerDbContext>();
                var expiredAppointments = dbContext.Appointments
                    .Where(a => a.AppointmentDate.AddHours(1) < DateTime.Now)
                    .ToList();

                if (expiredAppointments.Any())
                {
                    dbContext.Appointments.RemoveRange(expiredAppointments);
                    dbContext.SaveChanges();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
