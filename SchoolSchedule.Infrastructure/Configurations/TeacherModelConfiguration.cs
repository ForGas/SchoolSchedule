using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Domain.LessonAggregate;

namespace SchoolSchedule.Infrastructure.Configurations;

#nullable disable
//public class TeacherModelConfiguration : IEntityTypeConfiguration<Teacher>
//{
//    public void Configure(EntityTypeBuilder<Teacher> builder)
//    {
//        builder.ToTable("Teachers");
//        builder.HasKey(x => x.Id);

//        builder.Property(x => x.Id);
//        builder.Property(x => x.FullName).HasMaxLength(256).IsRequired();
//        builder.Property(x => x.Subjects);
//        builder.Property(x => x.EducationalClass).IsRequired(false);
//        builder.Property(x => x.EducationalClassId).IsRequired(false);
//        builder.Ignore(x => x.DomainEvents);

//        builder.Metadata.FindNavigation(nameof(Teacher.Subjects))
//            .SetPropertyAccessMode(PropertyAccessMode.Field);

//        builder.OwnsMany(t => t.Subjects, s =>
//        {
//            s.WithOwner().HasForeignKey("SubjectId");
//            s.Property<Guid>("Id");
//            s.HasKey("Id");

//            s.Property(x => x.Name).HasColumnName("Subject").IsRequired();
//        });
//    }
//}
