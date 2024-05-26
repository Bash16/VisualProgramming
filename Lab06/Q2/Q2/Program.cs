using System;
using System.Collections.Generic;

namespace Q2
{
    public class Customer
    {
        protected int customerId;
        protected string firstName;
        protected string lastName;
        protected string street;
        protected string city;
        protected string state;
        protected string zipCode;
        protected string phone;
        protected string email;
        protected string password;
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public List<Reservation> Reservations { get; } = new List<Reservation>();
    }

    // Reservation class
    public class Reservation
    {
        protected int reservationNo;
        protected DateTime date;
        protected List<Seat> seats = new List<Seat>();
        public int ReservationNo
        {
            get { return reservationNo; }
            set { reservationNo = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public List<Seat> Seats { get { return seats; } }
    }

    public class Seat
    {
        protected int rowNo;
        protected string seatNo;
        protected decimal price;
        protected string status;
        public int RowNo
        {
            get { return rowNo; }
            set { rowNo = value; }
        }
        public string SeatNo
        {
            get { return seatNo; }
            set { seatNo = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }

    public class Flight
    {
        protected int flightId;
        protected DateTime date;
        protected string origin;
        protected string destination;
        protected DateTime departureTime;
        protected DateTime arrivalTime;
        protected int seatingCapacity;
        protected List<Seat> seats = new List<Seat>();
        public int FlightId
        {
            get { return flightId; }
            set { flightId = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public DateTime DepartureTime
        {
            get { return departureTime; }
            set { departureTime = value; }
        }
        public DateTime ArrivalTime
        {
            get { return arrivalTime; }
            set { arrivalTime = value; }
        }
        public int SeatingCapacity
        {
            get { return seatingCapacity; }
            set { seatingCapacity = value; }
        }
        public List<Seat> Seats { get { return seats; } }
    }

    public class RetailCustomer : Customer
    {
        protected string creditCardType;
        protected string creditCardNo;
        public string CreditCardType
        {
            get { return creditCardType; }
            set { creditCardType = value; }
        }
        public string CreditCardNo
        {
            get { return creditCardNo; }
            set { creditCardNo = value; }
        }
    }

    public class CorporateCustomer : Customer
    {
        protected string companyName;
        protected int frequentFlyerPts;
        protected string billingAccountNo;
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        public int FrequentFlyerPts
        {
            get { return frequentFlyerPts; }
            set { frequentFlyerPts = value; }
        }
        public string BillingAccountNo
        {
            get { return billingAccountNo; }
            set { billingAccountNo = value; }
        }
    }
    class Program
    {
        static void Main()
        {
            // Create a customer
            Customer customer = new Customer();
            customer.CustomerId = 1;
            customer.FirstName = "John";
            customer.LastName = "Doe";
            customer.Street = "123 Main St";
            customer.City = "New York";
            customer.State = "NY";
            customer.ZipCode = "10001";
            customer.Phone = "555-123-4567";
            customer.Email = "johndoe@example.com";
            customer.Password = "password123";

            // Create a reservation for the customer
            Reservation reservation = new Reservation();
            reservation.ReservationNo = 101;
            reservation.Date = DateTime.Now;

            // Create seats for the reservation
            Seat seat1 = new Seat();
            seat1.RowNo = 1;
            seat1.SeatNo = "A1";
            seat1.Price = 100.0M;
            seat1.Status = "Booked";

            Seat seat2 = new Seat();
            seat2.RowNo = 2;
            seat2.SeatNo = "B1";
            seat2.Price = 90.0M;
            seat2.Status = "Booked";

            // Add seats to the reservation
            reservation.Seats.Add(seat1);
            reservation.Seats.Add(seat2);

            // Add the reservation to the customer's list of reservations
            customer.Reservations.Add(reservation);

            // Create a flight
            Flight flight = new Flight();
            flight.FlightId = 1;
            flight.Date = DateTime.Now.AddDays(7);
            flight.Origin = "New York";
            flight.Destination = "Los Angeles";
            flight.DepartureTime = DateTime.Parse("14:00");
            flight.ArrivalTime = DateTime.Parse("16:30");
            flight.SeatingCapacity = 150;

            // Add seats to the flight
            Seat flightSeat1 = new Seat();
            flightSeat1.RowNo = 1;
            flightSeat1.SeatNo = "A1";
            flightSeat1.Price = 100.0M;
            flightSeat1.Status = "Available";

            Seat flightSeat2 = new Seat();
            flightSeat2.RowNo = 1;
            flightSeat2.SeatNo = "A2";
            flightSeat2.Price = 100.0M;
            flightSeat2.Status = "Available";

            flight.Seats.Add(flightSeat1);
            flight.Seats.Add(flightSeat2);

            // Create a retail customer
            RetailCustomer retailCustomer = new RetailCustomer();
            retailCustomer.CustomerId = 2;
            retailCustomer.FirstName = "Jane";
            retailCustomer.LastName = "Smith";
            retailCustomer.Street = "456 Elm St";
            retailCustomer.City = "Los Angeles";
            retailCustomer.State = "CA";
            retailCustomer.ZipCode = "90001";
            retailCustomer.Phone = "555-987-6543";
            retailCustomer.Email = "janesmith@example.com";
            retailCustomer.Password = "retailpassword";
            retailCustomer.CreditCardType = "Visa";
            retailCustomer.CreditCardNo = "1234-5678-9012-3456";

            // Display customer details
            Console.WriteLine("Customer Details:");
            Console.WriteLine($"Customer Name: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Customer Email: {customer.Email}");
            Console.WriteLine($"Number of Reservations: {customer.Reservations.Count}");

            // Display flight details
            Console.WriteLine("\nFlight Details:");
            Console.WriteLine($"Flight Origin: {flight.Origin}");
            Console.WriteLine($"Flight Destination: {flight.Destination}");
            Console.WriteLine($"Departure Time: {flight.DepartureTime:HH:mm}");
            Console.WriteLine($"Arrival Time: {flight.ArrivalTime:HH:mm}");
            Console.WriteLine($"Seating Capacity: {flight.SeatingCapacity}");

            // Display retail customer details
            Console.WriteLine("\nRetail Customer Details:");
            Console.WriteLine($"Retail Customer Name: {retailCustomer.FirstName} {retailCustomer.LastName}");
            Console.WriteLine($"Retail Customer Email: {retailCustomer.Email}");
            Console.WriteLine($"Retail Customer Credit Card Type: {retailCustomer.CreditCardType}");
        }
    }
}