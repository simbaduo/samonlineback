using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using samonlineback.Models;

namespace samonlineback.Migrations
{
  public partial class GenerateEmail : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {

    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }

    internal Task SendEmail(Appointment newAppointment)
    {
      throw new NotImplementedException();
    }
  }
}
