using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Core.Domain.Entities
{
    public class Airplane
    {
        protected Airplane()
        {
        }

        public Airplane(Guid id, string name, string serialNumber, string model, string createdBy)
        {
            Id = id;
            Name = name;
            SerialNumber = serialNumber;
            Model = model;
            CreatedBy = createdBy;
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string SerialNumber { get; protected set; }
        public string Model { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public string CreatedBy { get; protected set; }
        public static Airplane Create(Guid id, string name, string serialNumber, string model, string createdBy)
        {
            return new Airplane(id, name, serialNumber, model, createdBy);
        }

        public void Update(string name, string serialNumber, string model)
        {
            Name = name;
            SerialNumber = serialNumber;
            Model = model;
        }
    }
}
