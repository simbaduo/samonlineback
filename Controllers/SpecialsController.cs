using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using samonlineback.Models;

namespace samonlineback.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SpecialsController : ControllerBase

  {
    static DatabaseContext Db = new DatabaseContext();

    [HttpPost]
    public async Task<ActionResult> CreateAppointment(Specials NewSpecials)
    {
      Db.Specials.Add(NewSpecials);
      await Db.SaveChangesAsync();
      return Ok(NewSpecials);
    }

    [HttpGet("All")]
    public ActionResult GetAll()
    {
      return Ok(Db.Specials);
    }

  }
}


