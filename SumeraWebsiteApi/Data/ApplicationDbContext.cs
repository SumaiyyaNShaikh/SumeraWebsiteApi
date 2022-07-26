using Microsoft.EntityFrameworkCore;
using SumeraWebsiteApi.Data.Models;

namespace SumeraWebsiteApi.Data
{
    public class ApplicationDbContext : DbContext
    {

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Amenities> Amenities { get; set; }
        public virtual DbSet<City> cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Hotel>Hotels { get; set; } 
        public virtual DbSet<HotelAmenitiesLink>HotelAmenitiesLinks { get; set; }
        public virtual DbSet<City> Citys { get; set; }

        public virtual DbSet<FlightShedule> FlightsShedules { get; set; }   
        public virtual DbSet<FlightBooking> FlightBookings { get; set; }
        public virtual DbSet<FlightCustomerDetails> FlightCustomerDetails { get; set; }

        public virtual DbSet<HotelBooking> HotelBookings { get; set; }
        public virtual DbSet<HotelCustomerDetails> HotelCustomerDetails { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
