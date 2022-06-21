using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Domain.SchoolDayScheduleAggregate;
using SchoolSchedule.Infrastructure.Services;

namespace SchoolSchedule.Infrastructure.Configurations;

public class SchoolDayScheduleModelConfiguration : IEntityTypeConfiguration<SchoolDaySchedule>
{
    public void Configure(EntityTypeBuilder<SchoolDaySchedule> builder)
    {
        builder.ToTable("Lessons");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.Day)
            .HasConversion<DateOnlyConverter, DateOnlyComparer>()
            .HasColumnType("date")
            .IsRequired();
        builder.Ignore(x => x.DomainEvents);
        builder.Ignore(x => x.RootType);

        builder.Metadata.FindNavigation(nameof(SchoolDaySchedule.IsActive))
           .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(x => x.Lessons).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
