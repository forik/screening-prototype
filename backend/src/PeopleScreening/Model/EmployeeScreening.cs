using System;

namespace PeopleScreening.Model
{
    public class EmployeeScreening
    {
        public long Id { get; set; }
        public Employee Employee { get; set; }
        public ScreeningProcess Screening { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }
        public DateTime? NotificationSentDate { get; set; }
        public bool NotificationIsInProgress { get; set; }
    }
}