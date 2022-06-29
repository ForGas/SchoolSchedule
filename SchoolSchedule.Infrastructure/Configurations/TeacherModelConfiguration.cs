using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSchedule.Infrastructure.Data.Models;

namespace SchoolSchedule.Infrastructure.Configurations;

#nullable disable
public class TeacherModelConfiguration : IEntityTypeConfiguration<TeacherSaveModel>
{
    public void Configure(EntityTypeBuilder<TeacherSaveModel> builder)
    {
        builder.ToTable("Teachers");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.FullName).HasMaxLength(256).IsRequired();
        builder.Property(x => x.EducationalClassId).IsRequired(false);
        builder.Ignore(x => x.Subjects);

        builder.OwnsMany(t => t.Subjects, s =>
        {
            s.WithOwner();
            s.ToTable("Subjects");
            s.Property(x => x.Name).HasColumnName("TeachSubjects");
        });

        builder.Navigation(x => x.Subjects).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
