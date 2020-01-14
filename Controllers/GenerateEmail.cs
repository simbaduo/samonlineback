using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using samonlineback.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace samonlineback.Controllers
{
  [ApiController]
  [Route("send/email")]
  public class GenerateEmailController : ControllerBase
  {
    private readonly string SENDGRID_API_KEY;
    public GenerateEmailController(IConfiguration configuration)
    {
      this.SENDGRID_API_KEY = configuration["SENDGRID_API_KEY"];
    }

    [HttpPost]
    public async Task<ActionResult> SendEmail(Appointment NewAppointment)
    {
      var client = new SendGridClient(this.SENDGRID_API_KEY);
      var from = new EmailAddress("appointment@gmail.com", "appointment maker");
      var subject = "New Appointment Request";
      var to = new EmailAddress("swandersautomart@gmail.com", "Customer");
      var plainTextContent = "Auto Reply";
      var htmlContent = $"<strong>First Name</strong>: {NewAppointment.FirstName}<br> <strong>Last Name</strong>: {NewAppointment.LastName} <br> <strong>Email</strong>: {NewAppointment.Email} <br>";
      var msg = new SendGridMessage()
      {
        From = from,
        Subject = subject,
        PlainTextContent = plainTextContent,
        HtmlContent = htmlContent,
      };
      // var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
      msg.AddTo(to);
      var response = await client.SendEmailAsync(msg);
      Console.WriteLine(response.StatusCode);
      return Ok(response);

    }
  }
}