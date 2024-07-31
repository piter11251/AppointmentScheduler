using AppointmentScheduler.Entities;
using AppointmentScheduler.Models;
using AppointmentScheduler.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppointmentScheduler.Controllers
{
    [Authorize(Policy = "CustomPolicy")]
    [Route("api/appointment")]
    public class AppointmentController: ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> GetAll()
        {
            var appointments = _appointmentService.GetAll();
            return Ok(appointments);
        }

        [HttpPost]
        public ActionResult CreateAppointment([FromBody] CreateAppointmentDto dto)
        {
            var userIdClaim = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _appointmentService.CreateAppointment(dto, userIdClaim);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAppointment([FromRoute] int id)
        {
            _appointmentService.DeleteAppointment(id, User);
            return NoContent();
        }

        [HttpGet("byDate")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByDate([FromQuery] DateTime dateTime)
        {
            var appointments = await _appointmentService.GetAppointmentsByDate(dateTime);
            return Ok(appointments);
        }
    }
}
