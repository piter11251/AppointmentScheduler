using AppointmentScheduler.Entities;
using AppointmentScheduler.Models;
using System.Security.Claims;

namespace AppointmentScheduler.Service
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentDto> GetAll();
        void CreateAppointment(CreateAppointmentDto dto);
        bool DeleteAppointment(int id);
        Task<List<AppointmentDto>> GetAppointmentsByDate(DateTime date);
    }
}
