using AppointmentScheduler.Entities;
using AppointmentScheduler.Models;
using AutoMapper;

namespace AppointmentScheduler
{
    public class AppointmentMappingProfile: Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(m => m.FirstName, c => c.MapFrom(s => s.User.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(s => s.User.LastName));

            CreateMap<User, UserDto>();
            CreateMap<CreateAppointmentDto, Appointment>();
        }
    }
}
