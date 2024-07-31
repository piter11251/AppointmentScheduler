using AppointmentScheduler.Models;

namespace AppointmentScheduler.Service
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginUserDto dto);
    }
}
