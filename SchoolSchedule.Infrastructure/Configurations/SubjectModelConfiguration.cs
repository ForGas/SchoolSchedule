using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Domain.LessonAggregate;

namespace SchoolSchedule.Infrastructure.Configurations;

//public class SubjectModelConfiguration : IEntityTypeConfiguration<Subject>
//{
//    public void Configure(EntityTypeBuilder<Subject> builder)
//    {
//        builder.ToTable("Subjects");
//        builder.Property<Guid>("Id").IsRequired();
//        builder.Property(x => x.Name).IsRequired();
//        builder.HasKey("Id");
//    }
//}
