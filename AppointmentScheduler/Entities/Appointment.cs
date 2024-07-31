namespace AppointmentScheduler.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
