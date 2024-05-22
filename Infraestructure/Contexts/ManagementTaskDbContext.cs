using Infrastructure.Contexts.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Contexts
{
    public class ManagementTaskDbContext : DbContext
    {
        public DbSet<Domain.Entities.TaskEntity> Tasks { get; set; }

        public ManagementTaskDbContext(DbContextOptions<ManagementTaskDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMapping());           

            foreach (var property in GetStringProperties(modelBuilder))
                property.SetIsUnicode(false);

            base.OnModelCreating(modelBuilder);
        }

        private static IEnumerable<IMutableProperty> GetStringProperties(ModelBuilder modelBuilder)
        {
            return modelBuilder.Model.GetEntityTypes()
                            .SelectMany(t => t.GetProperties())
                            .Where(p => p.ClrType == typeof(string) && p.GetColumnType() == null);
        }
    }
}
