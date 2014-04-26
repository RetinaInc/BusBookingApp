using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripodea.BusDomain;

namespace Tripodea.BusDataAccess
{
    //configuration for bus and company
    //public class BusConfiguration : EntityTypeConfiguration<BusType>
    //{
    //    public BusConfiguration()
    //    {
    //        HasRequired(b => b.Company)
    //            .WithMany(c => c.Buses)
    //            .WillCascadeOnDelete(true);

    //    }
    //}

    //configuration for seat and bus
    //public class SeatConfiguration : EntityTypeConfiguration<Seat_old>
    //{
    //    public SeatConfiguration()
    //    {
    //        HasRequired(b => b.Bus)
    //            .WithMany(c => c.Seats)
    //            .WillCascadeOnDelete(true);
    //    }
    //}

    //configuration for schedule and location
    public class ScheduleConfiguration : EntityTypeConfiguration<Schedule>
    {
        public ScheduleConfiguration()
        {
            HasRequired(s => s.JourneyFrom)
                .WithMany(l => l.FromSchedules)
                .HasForeignKey(s => s.JourneyFromId)
                .WillCascadeOnDelete(false);

            HasRequired(s => s.JourneyTo)
                .WithMany(l => l.ToSchedules)
                .HasForeignKey(s => s.JourneyToId)
                .WillCascadeOnDelete(false);
        }
    }
}
