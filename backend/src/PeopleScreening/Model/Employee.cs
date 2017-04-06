using System.Collections.Generic;

namespace PeopleScreening.Model
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public string TeamName { get; set; }
        public Employee Manager { get; set; }
        public Employee SkipManager { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}