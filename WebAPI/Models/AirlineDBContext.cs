using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class AirlineDBContext:DbContext
    {
        public AirlineDBContext(DbContextOptions<AirlineDBContext>options):base(options)
        {

        }

        public DbSet<DAirlines> DAirlines { get; set; }
    }
}
