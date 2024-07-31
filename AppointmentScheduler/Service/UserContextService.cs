using System.Security.Claims;

namespace AppointmentScheduler.Service
{
    
    public class UserContextService: IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        public UserContextService(IHttpContextAccessor httpContextAccesor)
        {
            _httpContextAccesor = httpContextAccesor;
        }

        public ClaimsPrincipal User => _httpContextAccesor.HttpContext?.User;
        public int? GetUserId =>
            User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}
