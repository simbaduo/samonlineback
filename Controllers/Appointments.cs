
using System;
namespace samonlinebackend.Models


{
  public class Appointment

  {
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public int Phone { get; set; }

    public string Reason { get; set; }

    public string Vehicle { get; set; }

    public DateTime Date { get; set; }

    public DateTime Time { get; set; }


    //this is a model because it represents a table
    //we name a property after a model if we need to interact with other models
    // we call; it a nav property because it defines a relationship with another model
  }


}