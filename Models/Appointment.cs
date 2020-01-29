
using System;
namespace samonlineback.Models


{
  public class Appointment

  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public string Reason { get; set; }
    public DateTime RequestedAppointment { get; set; }
    public DateTime SecondChoiceAppointment { get; set; }
    public bool Addressed { get; set; } = false;





  }


}