using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Domain;
using SchoolSchedule.Infrastructure.Data;

namespace SchoolSchedule.Infrastructure.Services
{
    public class CommandStudentRepository : CommandBaseRepository<Student>, ICommandStudentRepository
    {
        public CommandStudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Guid> EnrollmentInSchoolAsync(Student student)
        {
            var transaction =  await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await SaveAsync(student);
                _ = await SaveChangesAsync(new CancellationToken());
                await transaction.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
    }
}
