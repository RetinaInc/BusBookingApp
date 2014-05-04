using System;
using System.Data.Entity.Migrations;
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
            
            context.Seats.AddOrUpdate(s => s.UniqueId,
                new Seat { SeatFormatId = 1, SeatClass = "Business", SeatNumber = "A1", UniqueId = "1-1"},
                new Seat { SeatFormatId = 1, SeatClass = "Business", SeatNumber = "A2", UniqueId = "1-2"},
                new Seat { SeatFormatId = 1, SeatClass = "Business", SeatNumber = "B1", UniqueId = "1-3"},
                new Seat { SeatFormatId = 1, SeatClass = "Business", SeatNumber = "B2", UniqueId = "1-4"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C1", UniqueId = "1-5"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C2", UniqueId = "1-6"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C3", UniqueId = "1-7"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "C4", UniqueId = "1-8"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D1", UniqueId = "1-9"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D2", UniqueId = "1-10"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D3", UniqueId = "1-11"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "D4", UniqueId = "1-12"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E1", UniqueId = "1-13"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E2", UniqueId = "1-14"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E3", UniqueId = "1-15"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "E4", UniqueId = "1-16"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F1", UniqueId = "1-17"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F2", UniqueId = "1-18"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F3", UniqueId = "1-19"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "F4", UniqueId = "1-20"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G1", UniqueId = "1-21"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G2", UniqueId = "1-22"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G3", UniqueId = "1-23"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "G4", UniqueId = "1-24"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "H1", UniqueId = "1-25"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "H2", UniqueId = "1-26"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "H3", UniqueId = "1-27"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "H4", UniqueId = "1-28"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "I1", UniqueId = "1-29"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "I2", UniqueId = "1-30"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "I3", UniqueId = "1-31"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "I4", UniqueId = "1-32"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "J1", UniqueId = "1-33"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "J2", UniqueId = "1-34"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "J3", UniqueId = "1-35"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "J4", UniqueId = "1-36"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "K1", UniqueId = "1-37"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "K2", UniqueId = "1-38"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "K3", UniqueId = "1-39"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "K4", UniqueId = "1-40"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "L1", UniqueId = "1-41"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "L2", UniqueId = "1-42"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "L3", UniqueId = "1-43"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "L4", UniqueId = "1-44"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "M1", UniqueId = "1-45"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "M2", UniqueId = "1-46"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "M3", UniqueId = "1-47"},
                new Seat { SeatFormatId = 1, SeatClass = "Economy", SeatNumber = "M4", UniqueId = "1-48"}
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
