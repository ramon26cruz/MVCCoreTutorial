using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Core.Domain.Entities;

namespace FlightManagement.Core.Domain.Repositories
{
    public interface IAirplaneRepository
    {
        Task<IEnumerable<Airplane>> GetAll();
        void Add(Airplane newAirplane);
        Airplane GetById(Guid id);
    }
}
