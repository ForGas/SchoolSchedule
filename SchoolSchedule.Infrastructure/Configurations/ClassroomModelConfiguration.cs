using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Domain.LessonAggregate;

namespace SchoolSchedule.Infrastructure.Configurations;

public class ClassroomModelConfiguration : IEntityTypeConfiguration<Classroom>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        builder.ToTable("Classrooms");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.Number).IsRequired();

        builder.Ignore(x => x.DomainEvents);
    }
}
