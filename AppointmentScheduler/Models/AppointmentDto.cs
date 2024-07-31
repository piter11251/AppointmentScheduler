namespace AppointmentScheduler.Models
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
