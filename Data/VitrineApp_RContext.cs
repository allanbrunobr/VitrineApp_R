using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsoleApp2.Serialization;

namespace VitrineApp_R.Data
{
    public class VitrineApp_RContext : DbContext
    {
        public VitrineApp_RContext (DbContextOptions<VitrineApp_RContext> options)
            : base(options)
        {
        }

        public DbSet<ConsoleApp2.Serialization.Item> Item { get; set; }
    }
}
