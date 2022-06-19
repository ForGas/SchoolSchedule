using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Domain.LessonAggregate;
using SchoolSchedule.Infrastructure.Data;

namespace SchoolSchedule.Infrastructure.Configurations;

#nullable disable
public class EducationalClassModelConfiguration : IEntityTypeConfiguration<EducationalClass>
{
    public void Configure(EntityTypeBuilder<EducationalClass> builder)
    {
        builder.ToTable("EducationalClasses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
        //builder.Property(x => x.ClassroomTeacher);
        builder.Ignore(x => x.DomainEvents);

        builder
            .HasMany(ec => ec.Students)
            .WithOne(ct => ct.EducationalClass)
            .HasForeignKey(ct => ct.EducationalClassId);

        var navigation = builder.Metadata.FindNavigation(nameof(EducationalClass.Students));
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        //builder.HasOne(ec => ec.ClassroomTeacher).WithOne(ct => ct.EducationalClass)
        //        .HasForeignKey<Teacher>(ct => ct.EducationalClassId);
    }
}
