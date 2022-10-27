using Microsoft.EntityFrameworkCore;
using WeatherApp.DAL.Entity;

namespace WeatherApp.Web.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Location> locations { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }


}