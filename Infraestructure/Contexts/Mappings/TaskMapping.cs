using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Mappings
{
    public class TaskMapping : IEntityTypeConfiguration<Domain.Entities.TaskEntity>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.TaskEntity> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(t => t.Id);


            builder.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Description)
              .HasMaxLength(500)
              .IsRequired();

            builder.Property(t => t.Status)
              .HasMaxLength(15)
              .IsRequired();

            builder.Property(t => t.EstimatePoints)              
              .IsRequired();

            builder.Property(t => t.CreateDate);
            builder.Property(t => t.ModifyDate);
            builder.Property(t => t.Deleted);

        }
    }
}
