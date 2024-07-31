using System.Security.Claims;

namespace AppointmentScheduler.Service
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int? GetUserId {  get; }
    }
}
