using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Core.Domain.Entities
{
    public class Tutor
    {
        protected Tutor()
        {
        }

        public Tutor(Guid id, string lastName, string firstName, string middleName, DateTime birthDate, string subject, string createdBy)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            Subject = subject;
            CreatedBy = createdBy;
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
