using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripodea.BusDomain;

namespace Tripodea.BusDataAccess
{
    public class InitializeDb
    {
        public static void Initialize(BusContext context)
        {
            // create seats
            context.SeatFormats.AddOrUpdate(f => f.Name,
                new SeatFormat { Name = "Format1" });

            context.SaveChanges();

            context.Seats.AddOrUpdate(s => s.SeatId,
                new Seat { SeatId = "01-01", SeatFormatId = 1, SeatClass = "Business", SeatNumber = "A1" },
                new Seat { SeatId = "01-02", SeatFormatId = 1, SeatClass = "Business", SeatNumber = "A2" },
                new Seat { SeatId = "01-03", SeatFormatId = 1, SeatClass = "Business", SeatNumber = "B1" },
                new Seat { SeatId = "01-04", SeatFormatId = 1, SeatClass = "Business", SeatNumber = "B2" },
                new Seat { SeatId = "01-05", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C1" },
                new Seat { SeatId = "01-06", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C2" },
                new Seat { SeatId = "01-07", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C3" },
                new Seat { SeatId = "01-08", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C4" },
                new Seat { SeatId = "01-09", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D1" },
                new Seat { SeatId = "01-10", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D2" },
                new Seat { SeatId = "01-11", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D3" },
                new Seat { SeatId = "01-12", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D4" },
                new Seat { SeatId = "01-13", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E1" },
                new Seat { SeatId = "01-14", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E2" },
                new Seat { SeatId = "01-15", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E3" },
                new Seat { SeatId = "01-16", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E4" },
                new Seat { SeatId = "01-17", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F1" },
                new Seat { SeatId = "01-18", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F2" },
                new Seat { SeatId = "01-19", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F3" },
                new Seat { SeatId = "01-20", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F4" },
                new Seat { SeatId = "01-21", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G1" },
                new Seat { SeatId = "01-22", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G2" },
                new Seat { SeatId = "01-23", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G3" },
                new Seat { SeatId = "01-24", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G4" },
                new Seat { SeatId = "01-25", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E1" },
                new Seat { SeatId = "01-26", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E2" },
                new Seat { SeatId = "01-27", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E3" },
                new Seat { SeatId = "01-28", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E4" },
                new Seat { SeatId = "01-29", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F1" },
                new Seat { SeatId = "01-30", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F2" },
                new Seat { SeatId = "01-31", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F3" },
                new Seat { SeatId = "01-32", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F4" },
                new Seat { SeatId = "01-33", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G1" },
                new Seat { SeatId = "01-34", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G2" },
                new Seat { SeatId = "01-35", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G3" },
                new Seat { SeatId = "01-36", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G4" },
                new Seat { SeatId = "01-37", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "H1" },
                new Seat { SeatId = "01-38", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "H2" },
                new Seat { SeatId = "01-39", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "H3" },
                new Seat { SeatId = "01-40", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "H4" },
                new Seat { SeatId = "01-41", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "I1" },
                new Seat { SeatId = "01-42", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "I2" },
                new Seat { SeatId = "01-43", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "I3" },
                new Seat { SeatId = "01-44", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "I4" },
                new Seat { SeatId = "01-45", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "J1" },
                new Seat { SeatId = "01-46", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "J2" },
                new Seat { SeatId = "01-47", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "J3" },
                new Seat { SeatId = "01-48", SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "J4" }
                );

            // create companies and bus types
            context.Companies.AddOrUpdate(c => c.Name,
                new Company { Name = "Shohagh Paribahan" },
                new Company { Name = "GreenLine Paribahan" },
                new Company { Name = "Shyamoli Paribahan" },
                new Company { Name = "Hanif Paribahan" },
                new Company { Name = "Saudia S. Aalam" });

            context.BuseTypes.AddOrUpdate(b => b.Name,
                new BusType { Name = "Volvo 48 Seater", SeatFormatId = 1 },
                new BusType { Name = "AC 48 Seater", SeatFormatId = 1 },
                new BusType { Name = "Non-AC 48 Seater", SeatFormatId = 1 });

            // create locations
            context.Locations.AddOrUpdate(l => l.Name,
                new Location { Name = "Dhaka" },
                new Location { Name = "Sylhet" },
                new Location { Name = "Chittagong" },
                new Location { Name = "Bandarban" },
                new Location { Name = "Coxs Bazar" },
                new Location { Name = "Rangamati" },
                new Location { Name = "Khulna" },
                new Location { Name = "Srimangal" },
                new Location { Name = "Jessore" },
                new Location { Name = "Rajshahi" });

            // create schedules
            context.Schedules.AddOrUpdate(s => s.DepartureTime,
                new Schedule
                {
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae consectetur ante. Aliquam hendrerit libero eros, sed condimentum ligula egestas et. Nam lacus neque, ornare.",
                    DepartureTime = DateTime.Parse("2014-06-23 08:00:00"),
                    JourneyFromId = 1,
                    JourneyToId = 2,
                    BusTypeId = 1,
                    CompanyId = 1
                },
                new Schedule
                {
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae consectetur ante. Aliquam hendrerit libero eros, sed condimentum ligula egestas et. Nam lacus neque, ornare.",
                    DepartureTime = DateTime.Parse("2014-06-23 12:00:00"),
                    JourneyFromId = 1,
                    JourneyToId = 2,
                    BusTypeId = 1,
                    CompanyId = 2
                });
        }
    }
}
