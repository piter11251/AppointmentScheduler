﻿using AppointmentScheduler.Authorization;
using AppointmentScheduler.Entities;
using AppointmentScheduler.Exceptions;
using AppointmentScheduler.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppointmentScheduler.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentSchedulerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;
        public AppointmentService(AppointmentSchedulerDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
        }
        public IEnumerable<AppointmentDto> GetAll()
        {
            var appointments = _dbContext.Appointments
                .Include(a => a.User).ToList();
            var appointmentsDto = _mapper.Map<List<AppointmentDto>>(appointments);
            return appointmentsDto;
        }

        public void CreateAppointment(CreateAppointmentDto dto, int userIdClaim)
        {
            var appointment = _mapper.Map<Appointment>(dto);
            appointment.UserId = userIdClaim;
            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();
        }

        public bool DeleteAppointment(int id, ClaimsPrincipal user)
        {
            var appointment = _dbContext.Appointments.FirstOrDefault(a => a.Id == id);
            if(appointment == null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(user, appointment, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if(!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<List<AppointmentDto>> GetAppointmentsByDate(DateTime date)
        {
            var appointments = await _dbContext.Appointments
                .Include(u => u.User)
                .Where(a => a.AppointmentDate.Date == date)
                .ToListAsync();

            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        /*
         Sending sms provider costs, so I will implement it in the future
         */
    }
}
