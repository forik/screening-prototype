using Microsoft.EntityFrameworkCore;
using PeopleScreening.Model;

namespace PeopleScreening.Data
{
    public class PeopleScreeningContext : DbContext
    {
        public PeopleScreeningContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var sequenceName = "EntityFrameworkCoreSequence";
            builder.ForSqlServerHasSequence(sequenceName, sequence =>
            {
                sequence.IncrementsBy(100);
            });

            var employeeEntity = builder.Entity<Employee>();
            employeeEntity.HasKey(x => x.Id);
            employeeEntity.Property(x => x.Id).ForSqlServerUseSequenceHiLo(sequenceName);
            employeeEntity.HasOne(x => x.Manager).WithMany(x => x.Employees);
            employeeEntity.HasOne(x => x.SkipManager);

            var screeningEntity = builder.Entity<ScreeningProcess>();
            screeningEntity.HasKey(x => x.Id);
            screeningEntity.Property(x => x.Id).ForSqlServerUseSequenceHiLo(sequenceName);

            var employeeScreeningEntity = builder.Entity<EmployeeScreening>();
            employeeScreeningEntity.HasKey(x => x.Id);
            employeeScreeningEntity.Property(x => x.Id).ForSqlServerUseSequenceHiLo(sequenceName);
            employeeScreeningEntity.HasOne(x => x.Employee);
            employeeScreeningEntity.HasOne(x => x.Screening);
        }
    }
}