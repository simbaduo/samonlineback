using System;
using System.Text.RegularExpressions;
using AuthExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace samonlineback.Models
{
  public partial class DatabaseContext : DbContext
  {


    public DbSet<Appointment> Appointment { get; set; }

    public DbSet<CarSales> CarSales { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Specials> Specials { get; set; }

    public DbSet<ContactUs> ContactUs { get; set; }

    public DbSet<Veteran> Veteran { get; set; }
    
    public DbSet<Reviews> Reviews { get; set; }
    //<Reviews> is the structure of the table, yellow Reviews is the name. They do not have to match we could call the second Reviews Title Banana if we so choose
    public DbSet<Resume> Resume { get; set; }
    //why is there no CarSearch DB set?
    private string ConvertPostConnectionToConnectionString(string connection)
    {
      var _connection = connection.Replace("postgres://", String.Empty);
      var output = Regex.Split(_connection, ":|@|/");
      return $"server={output[2]};database={output[4]};User Id={output[0]}; password={output[1]}; port={output[3]}";
    }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var envConn = Environment.GetEnvironmentVariable("DATABASE_URL");
        var conn = "server=localhost;database=samonlineback";
        if (envConn != null)
        {
          conn = ConvertPostConnectionToConnectionString(envConn);
        }
        optionsBuilder.UseNpgsql(conn);
      }
    }



  }
}
