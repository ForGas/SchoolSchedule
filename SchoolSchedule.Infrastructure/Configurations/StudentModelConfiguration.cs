using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Infrastructure.Services;

namespace SchoolSchedule.Infrastructure.Configurations;

#nullable disable
public class StudentModelConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.FullName).HasMaxLength(256).IsRequired();
        builder.Property(x => x.BirthYear)
            .HasConversion<DateOnlyConverter, DateOnlyComparer>()
            .HasColumnType("date")
            .IsRequired();

        builder.Metadata.FindNavigation(nameof(Student.EducationalClass))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
