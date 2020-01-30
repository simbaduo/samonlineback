using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using samonlineback.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace samonlineback.Controllers
{
  public class GenerateEmail22
  {
    private readonly string SENDGRID_API_KEY;

    public GenerateEmail22(IConfiguration configuration)
    
    {
      this.SENDGRID_API_KEY = configuration["SENDGRID_API_KEY"];
    }


    public async Task<Response> SendEmail(Appointment NewAppointment)
    {
      var client = new SendGridClient(this.SENDGRID_API_KEY);
      var from = new EmailAddress("appointment@gmail.com", "Requested Customer");
      var subject = "New Appointment Request";
      var to = new EmailAddress("swandersautomart@gmail.com", "Customer");
      var plainTextContent = "Auto Reply";
      var htmlContent = $"<strong>First Name</strong>: {NewAppointment.FirstName}<br> <strong>Last Name</strong>: {NewAppointment.LastName} <br> <strong>Email</strong>: {NewAppointment.Email} <br>";
      // var msg = new SendGridMessage()
      // {
      //   From = from,
      //   Subject = subject,
      //   PlainTextContent = plainTextContent,
      //   HtmlContent = htmlContent,
      // };
      var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
      // msg.AddTo(to);
      var response = await client.SendEmailAsync(msg);
      return response;
    }


    public async Task<Response> ReplyEmail(Appointment NewAppointment, string selectedDate)
    {
      var client = new SendGridClient(this.SENDGRID_API_KEY);
      var from = new EmailAddress("swandersautomart@gmail.com", "Appointment Confirmation");
      var subject = "New Appointment Request";
      var to = new EmailAddress($"{NewAppointment.Email}", "Customer");
      var selected = selectedDate == "first" ? NewAppointment.RequestedAppointment : NewAppointment.SecondChoiceAppointment;
      var plainTextContent = $"We have confirmed your appointment for {selected}";
      var htmlContent = $"<strong>First Name</strong>: {NewAppointment.FirstName}<br> <strong>Last Name</strong>: {NewAppointment.LastName} <br> <strong>Email</strong>: {NewAppointment.Email} <br>{plainTextContent}";
      // var msg = new SendGridMessage()
      // {
      //   From = from,
      //   Subject = subject,
      //   PlainTextContent = plainTextContent,
      //   HtmlContent = htmlContent,
      // };
      var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
      // msg.AddTo(to);
      var response = await client.SendEmailAsync(msg);
      return response;
    }



  }
}