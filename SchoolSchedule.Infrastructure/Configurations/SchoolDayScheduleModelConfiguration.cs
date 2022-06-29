using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Infrastructure.Data.Models;
using SchoolSchedule.Infrastructure.Services;

namespace SchoolSchedule.Infrastructure.Configurations;

public class SchoolDayScheduleModelConfiguration : IEntityTypeConfiguration<SchoolDayScheduleSaveModel>
{
    public void Configure(EntityTypeBuilder<SchoolDayScheduleSaveModel> builder)
    {
        builder.ToTable("SchoolDaySchedules");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.Day)
            .HasConversion<DateOnlyConverter, DateOnlyComparer>()
            .HasColumnType("date")
            .IsRequired();

        builder.Navigation(x => x.Lessons).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
