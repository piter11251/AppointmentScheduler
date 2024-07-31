﻿namespace AppointmentScheduler.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ContactNumber { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
