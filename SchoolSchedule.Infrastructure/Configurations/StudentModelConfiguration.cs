using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Domain.EducationalClassAggregate;

namespace SchoolSchedule.Infrastructure.Configurations;

public class StudentModelConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.FullName).HasMaxLength(256).IsRequired();
        builder.Property(x => x.BirthYear).IsRequired();
        builder.Ignore(x => x.DomainEvents);

        var navigation = builder.Metadata.FindNavigation(nameof(Student.EducationalClass));
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
