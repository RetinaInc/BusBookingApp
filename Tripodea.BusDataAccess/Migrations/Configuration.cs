namespace Tripodea.BusDataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tripodea.BusDomain;

    internal sealed class Configuration : DbMigrationsConfiguration<Tripodea.BusDataAccess.BusContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Tripodea.BusDataAccess.BusContext context)
        {
            // create seats
            context.SeatFormats.AddOrUpdate(f => f.Name,
                new SeatFormat { Name = "Format1" });

            context.Seats.AddOrUpdate(s => s.SeatNumber,
                new Seat { SeatFormatId = 1, SeatClass = "Business", SeatNumber = "A1" },
                new Seat { SeatFormatId = 1, SeatClass = "Business", SeatNumber = "A2" },
                new Seat { SeatFormatId = 1, SeatClass = "Business", SeatNumber = "B1" },
                new Seat { SeatFormatId = 1, SeatClass = "Business", SeatNumber = "B2" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C1" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C2" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C3" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C4" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D1" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D2" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D3" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D4" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E1" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E2" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E3" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E4" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F1" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F2" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F3" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F4" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G1" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G2" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G3" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G4" },
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G5" });

            // create companies and bus types
            context.Companies.AddOrUpdate(c => c.CompanyId,
                new Company { Name = "Shohagh Paribahan" },
                new Company { Name = "GreenLine Paribahan" },
                new Company { Name = "Shyamoli Paribahan" },
                new Company { Name = "Hanif Paribahan" },
                new Company { Name = "Saudia S. Aalam" });

            context.BuseTypes.AddOrUpdate(b => b.BusTypeId,
                new BusType { Name = "Volvo 48 Seater", SeatFormatId = 1 },
                new BusType { Name = "AC 48 Seater", SeatFormatId = 1 },
                new BusType { Name = "Non-AC 48 Seater", SeatFormatId = 1 });

            // create locations
            context.Locations.AddOrUpdate(l => l.Name,
                new Location { Name = "Dhaka" },
                new Location { Name = "Khulna" },
                new Location { Name = "Chittagong" },
                new Location { Name = "Bandarban" },
                new Location { Name = "Coxs Bazar" },
                new Location { Name = "Rangamati" },
                new Location { Name = "Sylhet" },
                new Location { Name = "Srimangal" },
                new Location { Name = "Jessore" },
                new Location { Name = "Rajshahi" });

            // create schedules
            context.Schedules.AddOrUpdate(s => s.DepartureTime,
                new Schedule
                {
                    DepartureTime = DateTime.Parse("2014-03-23 08:00:00"),
                    JourneyFromId = 1,
                    JourneyToId = 2,
                    BusTypeId = 1,
                    CompanyId = 1
                },
                new Schedule
                {
                    DepartureTime = DateTime.Parse("2014-03-23 12:00:00"),
                    JourneyFromId = 1,
                    JourneyToId = 2,
                    BusTypeId = 1,
                    CompanyId = 2
                });
        }
    }
}
