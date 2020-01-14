using Microsoft.AspNetCore.Mvc;
using samonlineback.Migrations;
using samonlineback.Models;
using System.Linq;
using System.Threading.Tasks;

namespace samonlineback.Controllers
{
  public class Email
  {
    [ApiController]
    [Route("api/[controller]")]

    public class EmailController : ControllerBase
    {
      static DatabaseContext Db = new DatabaseContext();
      [HttpPost]

      public async Task<ActionResult> CreateAppointment(Appointment NewAppointment)
      {
        Db.Appointments.Add(NewAppointment);
        Db.SaveChanges();
        var generateEmail = new GenerateEmail();
        await generateEmail.SendEmail(NewAppointment);
        return Ok(NewAppointment);
      }



      [HttpGet("All")]
      public ActionResult GetAllNurses()
      {
        return Ok(Db.Appointments);
      }

    }
  }
}