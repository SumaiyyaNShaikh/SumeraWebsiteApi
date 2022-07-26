using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SumeraWebsiteApi.Migrations
{
    public partial class sumeraTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "transaction");

            migrationBuilder.EnsureSchema(
                name: "master");

            migrationBuilder.CreateTable(
                name: "Amenities",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CountryRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryRefId",
                        column: x => x.CountryRefId,
                        principalSchema: "master",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airline",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ShortName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Telephone1 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Email1 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airline_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Telephone1 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Email1 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airport_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    star = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineRefId = table.Column<int>(type: "int", nullable: true),
                    FromAirportRefId = table.Column<int>(type: "int", nullable: true),
                    ToAirportRefId = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Telephone1 = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Email1 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineRefId",
                        column: x => x.AirlineRefId,
                        principalSchema: "master",
                        principalTable: "Airline",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_Airport_FromAirportRefId",
                        column: x => x.FromAirportRefId,
                        principalSchema: "master",
                        principalTable: "Airport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_Airport_ToAirportRefId",
                        column: x => x.ToAirportRefId,
                        principalSchema: "master",
                        principalTable: "Airport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HotelAmenitiesLink",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRefId = table.Column<int>(type: "int", nullable: true),
                    AmenitiesRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenitiesLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_Amenities_AmenitiesRefId",
                        column: x => x.AmenitiesRefId,
                        principalSchema: "master",
                        principalTable: "Amenities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalSchema: "master",
                        principalTable: "Hotel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HotelBooking",
                schema: "transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRefId = table.Column<int>(type: "int", nullable: true),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelBooking_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalSchema: "master",
                        principalTable: "Hotel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: " FlightBooking",
                schema: "transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerNameRecord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerRefId = table.Column<int>(type: "int", nullable: true),
                    FlightScheduleRefId = table.Column<int>(type: "int", nullable: true),
                    CustomerContactMobile = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    CustomerContactEmail = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ FlightBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ FlightBooking_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalSchema: "master",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ FlightBooking_Flight_FlightScheduleRefId",
                        column: x => x.FlightScheduleRefId,
                        principalSchema: "master",
                        principalTable: "Flight",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlightShedule",
                schema: "transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightRefId = table.Column<int>(type: "int", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightShedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightShedule_Flight_FlightRefId",
                        column: x => x.FlightRefId,
                        principalSchema: "master",
                        principalTable: "Flight",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HotelCustomerDetails",
                schema: "transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelBookingRefId = table.Column<int>(type: "int", nullable: true),
                    CustomerRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelCustomerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelCustomerDetails_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalSchema: "master",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HotelCustomerDetails_HotelBooking_HotelBookingRefId",
                        column: x => x.HotelBookingRefId,
                        principalSchema: "transaction",
                        principalTable: "HotelBooking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlightCustomerDetails",
                schema: "transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightBookingRefId = table.Column<int>(type: "int", nullable: true),
                    CustomerRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightCustomerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightCustomerDetails_ FlightBooking_FlightBookingRefId",
                        column: x => x.FlightBookingRefId,
                        principalSchema: "transaction",
                        principalTable: " FlightBooking",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightCustomerDetails_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalSchema: "master",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ FlightBooking_CustomerRefId",
                schema: "transaction",
                table: " FlightBooking",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_ FlightBooking_FlightScheduleRefId",
                schema: "transaction",
                table: " FlightBooking",
                column: "FlightScheduleRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Airline_CityRefId",
                schema: "master",
                table: "Airline",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Airport_CityRefId",
                schema: "master",
                table: "Airport",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryRefId",
                schema: "master",
                table: "City",
                column: "CountryRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityRefId",
                schema: "master",
                table: "Customer",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineRefId",
                schema: "master",
                table: "Flight",
                column: "AirlineRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_CityRefId",
                schema: "master",
                table: "Flight",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FromAirportRefId",
                schema: "master",
                table: "Flight",
                column: "FromAirportRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ToAirportRefId",
                schema: "master",
                table: "Flight",
                column: "ToAirportRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCustomerDetails_CustomerRefId",
                schema: "transaction",
                table: "FlightCustomerDetails",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCustomerDetails_FlightBookingRefId",
                schema: "transaction",
                table: "FlightCustomerDetails",
                column: "FlightBookingRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightShedule_FlightRefId",
                schema: "transaction",
                table: "FlightShedule",
                column: "FlightRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CityRefId",
                schema: "master",
                table: "Hotel",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_AmenitiesRefId",
                schema: "master",
                table: "HotelAmenitiesLink",
                column: "AmenitiesRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_HotelRefId",
                schema: "master",
                table: "HotelAmenitiesLink",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBooking_HotelRefId",
                schema: "transaction",
                table: "HotelBooking",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelCustomerDetails_CustomerRefId",
                schema: "transaction",
                table: "HotelCustomerDetails",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelCustomerDetails_HotelBookingRefId",
                schema: "transaction",
                table: "HotelCustomerDetails",
                column: "HotelBookingRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightCustomerDetails",
                schema: "transaction");

            migrationBuilder.DropTable(
                name: "FlightShedule",
                schema: "transaction");

            migrationBuilder.DropTable(
                name: "HotelAmenitiesLink",
                schema: "master");

            migrationBuilder.DropTable(
                name: "HotelCustomerDetails",
                schema: "transaction");

            migrationBuilder.DropTable(
                name: " FlightBooking",
                schema: "transaction");

            migrationBuilder.DropTable(
                name: "Amenities",
                schema: "master");

            migrationBuilder.DropTable(
                name: "HotelBooking",
                schema: "transaction");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Flight",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Hotel",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Airline",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Airport",
                schema: "master");

            migrationBuilder.DropTable(
                name: "City",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "master");
        }
    }
}
