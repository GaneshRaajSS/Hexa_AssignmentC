using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Model
{

    internal class Booking
    {
        private static int id = 1;

        public int EventId { get; set; }
        int bookingId;
        Customer[] customer;
        Event _event;
        int numTickets;
        int totalCost;
        DateTime bookingDate;

        public int BookingId
        {
            get { return bookingId; } 
            private set {  bookingId = value; }
        }

        public Customer[] Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        public Event Event
        {
            get { return _event;}
            set { _event = value; }
        }
        public int NumTickets
        {
            get { return numTickets; }
            set { numTickets = value; }
        }
        public int TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
        public DateTime BookingDate
        {
            get { return bookingDate; }
            set { bookingDate = value; }
        }

        public Booking() {
            bookingId = id++;
            BookingDate = DateTime.Now;
        }

        public Booking(Customer[] customers,Event _event, int numTickets, int totalCost, DateTime bookingDate, int eventId)
        {
            Customer = customers;
            Event = _event;
            NumTickets = numTickets;
            TotalCost = totalCost;
            BookingDate = bookingDate;
            BookingId = id++;
            EventId = eventId;
        }

        public void DisplayBookingDetails()
        {
            Console.WriteLine($"Booking ID: {BookingId}");
            Console.WriteLine($"Event Name: {Event.EventName}");
            Console.WriteLine($"Number of Tickets: {NumTickets}");
            Console.WriteLine($"Total Cost: {TotalCost}");
            Console.WriteLine($"Booking Date: {BookingDate}");
            Console.WriteLine("Customer(s):");
            foreach (var customer in Customer)
            {
                Console.WriteLine($"{customer.CustomerName}");
            }
        }
    }
}
