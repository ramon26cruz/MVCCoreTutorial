using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Core.Domain.Entities
{
    public class Airport
    {
        protected Airport()
        {
            
        }
        private Airport(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public static Airport Create(Guid id, string name, string address)
        {
            return new Airport(id, name, address);
        }
    }
}
