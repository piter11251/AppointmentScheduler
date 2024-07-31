using AppointmentScheduler.Entities;
using AppointmentScheduler.Models;
using System.Security.Claims;

namespace AppointmentScheduler.Service
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentDto> GetAll();
        void CreateAppointment(CreateAppointmentDto dto, int userIdClaim);
        bool DeleteAppointment(int id, ClaimsPrincipal user);
        Task<List<AppointmentDto>> GetAppointmentsByDate(DateTime date);
    }
}
