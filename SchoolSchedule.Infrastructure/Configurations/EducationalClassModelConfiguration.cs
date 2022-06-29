using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Infrastructure.Data.Models;

namespace SchoolSchedule.Infrastructure.Configurations;

#nullable disable
public class EducationalClassModelConfiguration : IEntityTypeConfiguration<EducationalSaveModel>
{
    public void Configure(EntityTypeBuilder<EducationalSaveModel> builder)
    {
        builder.ToTable("EducationalClasses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(64).IsRequired();

        builder
            .HasMany(ec => ec.Students)
            .WithOne(ct => ct.EducationalClass)
            .HasForeignKey(ct => ct.EducationalClassId);
    }
}
