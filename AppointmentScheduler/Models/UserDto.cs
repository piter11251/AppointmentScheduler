using AppointmentScheduler.Entities;

namespace AppointmentScheduler.Models
{
    public class UserDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<AppointmentDto>? Appointments { get; set; }
    }
}
