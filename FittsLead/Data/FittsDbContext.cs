using FittsLead.Models;
using Microsoft.EntityFrameworkCore;

namespace FittsLead.Data
{
    public class FittsDbContext : DbContext
    {
        public FittsDbContext(DbContextOptions<FittsDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FittsLead.db");
        }

        public DbSet<FittsUser> FittsUsers { get; set; }
        public DbSet<FittsObject> FittsObjects { get; set; }
        public DbSet<ClipRectangle> ClipRectangles { get; set; }
        public DbSet<ClickedPoint> ClickedPoints { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<StageThreshold> StageThresholders { get; set; }

    }
}
