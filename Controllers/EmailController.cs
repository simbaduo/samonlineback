using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using samonlineback.Migrations;
using samonlineback.Models;
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
      var key = new GenerateEmail22(this.configuration).SendEmail(NewAppointment);
      return Ok(NewAppointment);
    }



    [HttpGet("All")]
    public ActionResult GetAll()
    {
      return Ok();
    }

  }
}
