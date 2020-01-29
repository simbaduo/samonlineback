using System.ComponentModel.DataAnnotations;

namespace AuthExample.Models
{
  public class Veteran
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public string Birthday { get; set; }
    public string MilitaryBranch { get; set; }
    public int YearsServed { get; set; }
    public string Rank { get; set; }
    public string Stationed { get; set; }
    public string Story { get; set; }


  }
}