using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Web.Data
{
    public class DbInitializer
    {
        private static ApplicationDbContext _context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
            _context.Database.Migrate();
        }
    }
}
