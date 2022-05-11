using Microsoft.EntityFrameworkCore;
using MotoDojo.Entities;

namespace MotoDojo.Context
{
    public class CoreContext : DbContext
    {
        public static readonly string DEFAULT_SCHEMA = "dojo";

        public DbSet<Moto> Motos { get; set; }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MotoEntityTypeConfiguration());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }
    }
}