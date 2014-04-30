using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripodea.BusDomain;


namespace Tripodea.BusDataAccess
{
    public class BusContext : DbContext
    {
        public BusContext() : base("AppDb") { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BusType> BuseTypes { get; set; }
        //public DbSet<Seat_old> Seats { get; set; }
        public DbSet<SeatFormat> SeatFormats { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove auto pluralization of table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //load specific configurations
            modelBuilder.Configurations.Add(new ScheduleConfiguration());

            // remove one to many cascade convention
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
