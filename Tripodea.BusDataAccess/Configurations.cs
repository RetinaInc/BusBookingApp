using System.Data.Entity.ModelConfiguration;
using Tripodea.BusDomain;

namespace Tripodea.BusDataAccess
{
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
