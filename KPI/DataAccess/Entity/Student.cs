using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
