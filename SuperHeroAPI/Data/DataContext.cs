using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public DataContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to mysql with connection string from app settings
        //    var connectionString = Configuration.GetConnectionString("Default");
        //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //}

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<SuperHero> SuperHeroes { get; set; }
  
    }
}
