using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Core.Domain.Entities;
using FlightManagement.Core.Domain.Repositories;
using FlightManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Infrastructure.Repositories
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly ApplicationDbContext _context;
        public AirplaneRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Airplane>> GetAll()
        {
            return await _context.Airplanes.ToListAsync();
        }
        public void Add(Airplane newAirplane)
        {
            _context.Airplanes.Add(newAirplane);
        }

        public Airplane GetById(Guid id)
        {
            var airplane = _context.Airplanes.Single(x => x.Id == id);
            if(airplane == null) throw new Exception($"Cannot find airplane with id {id}");
            return airplane;
        }
    }
}
