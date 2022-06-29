using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Infrastructure.Data.Models;
using SchoolSchedule.Infrastructure.Services;

namespace SchoolSchedule.Infrastructure.Configurations;

public class LessonModelConfiguration : IEntityTypeConfiguration<LessonModel>
{
    public void Configure(EntityTypeBuilder<LessonModel> builder)
    {
        builder.ToTable("Lessons");

        builder.Property(x => x.SubjectName).IsRequired();
        builder.Property(x => x.StartTime)
           .HasConversion<TimeOnlyConverter, TimeOnlyComparer>()
           .HasColumnType("date")
           .IsRequired();
        builder.Property(x => x.EndTime)
           .HasConversion<TimeOnlyConverter, TimeOnlyComparer>()
           .HasColumnType("date")
           .IsRequired();

        builder.HasOne(l => l.SchoolDaySchedule).WithMany(sds => sds.Lessons)
            .HasForeignKey(x => x.SchoolDayScheduleId);

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
