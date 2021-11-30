using Microsoft.EntityFrameworkCore;

namespace BlazorStudentsApp.Data
{
    public class DatabaseDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
                : base(options)
        {
            Database.EnsureCreated();
        }

        #region Public properties

        public DbSet<ClassesData> Classes { get; set; }

        public DbSet<CountriesData> Countries { get; set; }

        public DbSet<StudentsData> Students { get; set; }
        #endregion
    }
}
