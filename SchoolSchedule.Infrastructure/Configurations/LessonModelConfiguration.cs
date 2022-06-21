using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Domain.LessonAggregate;
using SchoolSchedule.Infrastructure.Services;

namespace SchoolSchedule.Infrastructure.Configurations;

public class LessonModelConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.SubjectName).IsRequired();
        builder.Property(x => x.StartTime)
           .HasConversion<TimeOnlyConverter, TimeOnlyComparer>()
           .HasColumnType("date")
           .IsRequired();
        builder.Property(x => x.EndTime)
           .HasConversion<TimeOnlyConverter, TimeOnlyComparer>()
           .HasColumnType("date")
           .IsRequired();
        builder.Ignore(x => x.DomainEvents);
        builder.Ignore(x => x.RootType);

        builder.Metadata.FindNavigation(nameof(Lesson.IsActive))
           .SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(Lesson.SchoolDaySchedule))
           .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasOne(l => l.SchoolDaySchedule).WithMany(sds => sds.Lessons)
            .HasForeignKey(x => x.SchoolDayScheduleId);

        builder.HasOne(l => l.EducationalClass).WithMany(sds => sds.Lessons);

        builder.OwnsOne(x => x.Classroom);

        builder.Navigation(x => x.Subject).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.OwnsOne(l => l.Subject, s =>
        {
            s.WithOwner();
            s.ToTable("LessonSubject");
            s.Property(x => x.Name).HasColumnName("TeachSubjects");
        });
    }
}
