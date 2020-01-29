using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using samonlineback.Migrations;
using samonlineback.Models;
using samonlineback.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace samonlineback.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class EmailController : ControllerBase
  {
    static DatabaseContext Db = new DatabaseContext();



    private readonly IConfiguration configuration;

    public EmailController(IConfiguration config)
    {
      this.configuration = config;
    }


    [HttpPost]
    public async Task<ActionResult> CreateAppointment(Appointment NewAppointment)
    {
      Db.Appointment.Add(NewAppointment);
      await Db.SaveChangesAsync();
      var emailResponse = new GenerateEmail22(this.configuration).SendEmail(NewAppointment);
      return Ok(NewAppointment);
    }

    [HttpPost("Reply")]
    public async Task<ActionResult> ReplyAppointment(AppointmentReply reply)
    {


      // get the appointment info
      var appointment = await Db.Appointment.FirstOrDefaultAsync(f => f.Id == reply.Id);
      if (!string.IsNullOrWhiteSpace(reply.Selected))
      {
        var emailResponse = new GenerateEmail22(this.configuration).ReplyEmail(appointment, reply.Selected);

      }
      appointment.Addressed = true;
      await Db.SaveChangesAsync();
      return Ok();

    }






    [HttpGet("All")]
    public ActionResult GetAll()
    {
      return Ok();
    }

  }
}
