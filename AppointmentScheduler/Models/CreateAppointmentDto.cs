namespace AppointmentScheduler.Models
{
    public class CreateAppointmentDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
