using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AuthExample.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using samonlineback.Models;

namespace AuthExample.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MeController : ControllerBase
  {


    private readonly DatabaseContext context;

    public MeController(DatabaseContext _context)
    {
      this.context = _context;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> GetUserData()
    {
      var userName = User.Identity.Name;

      var user = this.context.Users.FirstOrDefault(f => f.Username == userName);

      return Ok(user);
    }
  }
}