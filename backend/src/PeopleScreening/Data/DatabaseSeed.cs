using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PeopleScreening.Model;
using PeopleScreening.Properties;

namespace PeopleScreening.Data
{
    public class DatabaseSeed
    {
        private readonly PeopleScreeningContext _context;

        public DatabaseSeed(PeopleScreeningContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Set<Employee>().Any())
            {
                return;
            }

            var employees = GenerateEmployees();
            var screenings = GenerateScreenings();
            GenerateEmployeeScreenings(employees, screenings);

            _context.SaveChanges();
        }

        private List<Employee> GenerateEmployees()
        {
            var fakes = JsonConvert.DeserializeObject<List<Employee>>(Resources.FakeEmployees);
            var employees = fakes.Take(450).ToList();
            var managers = fakes.Skip(450).Take(50).ToArray();
            var rnd = new Random();

            Parallel.ForEach(employees, employee =>
            {
                employee.Manager = managers[rnd.Next(0, 49)];
                employee.SkipManager = managers[rnd.Next(0, 49)];
            });
            
            _context.Set<Employee>().AddRange(employees);

            return employees;
        }

        private List<ScreeningProcess> GenerateScreenings()
        {
            var fakes = JsonConvert.DeserializeObject<List<ScreeningProcess>>(Resources.FakeScreenings);
            _context.Set<ScreeningProcess>().AddRange(fakes);

            return fakes;
        }

        private void GenerateEmployeeScreenings(
            List<Employee> employees,
            List<ScreeningProcess> screenings)
        {
            var rnd = new Random();
            var statuses = new[] {"Applicable", "Not Applicable", "Status 3", "Status 4"};

            foreach (var employee in employees)
            {
                foreach (var screening in screenings)
                {
                    var employeeScreening = new EmployeeScreening
                    {
                        Employee = employee,
                        Screening = screening,
                        StartDate = DateTime.UtcNow.AddDays(-rnd.Next(1, 200)),
                        EndDate = rnd.Next() % 3 == 0 ? (DateTime?)null : DateTime.UtcNow.AddDays(rnd.Next(1, 50)),
                        ExpirationDate = DateTime.UtcNow.AddDays(rnd.Next(-30, 30)),
                        Status = statuses[rnd.Next(0, 3)]
                    };

                    _context.Add(employeeScreening);
                }
            }
        }
    }
}
