using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Model;
using TicketManagementSystem.Util;

namespace TicketManagementSystem.Repository
{
    internal class BookingRepo
    {
        Booking booking1 = new Booking();
        EventRepo eventRepo;

        public BookingRepo(EventRepo eventRepo)
        {
            this.eventRepo = eventRepo; 
        }

        public decimal CalculateBookingCost(int numTickets, decimal ticketPrice)
        {
            return numTickets * ticketPrice;
        }

        public void BookTickets(string eventName, int numTickets, Customer[] arrayOfCustomer)
        {
            eventRepo.BookTickets(eventName,numTickets,arrayOfCustomer);
        }

        public void CancelBooking(int bookingId)
        {
            eventRepo.CancelBooking(bookingId);
        }

        public void ViewBooking(int bookingId, List<Booking> bookings)
        {
            Booking booking = bookings.Find(b => b.BookingId == bookingId);
            if (booking == null)
            {
                throw new ArgumentException($"Invalid booking ID: {bookingId}");
            }

            booking1.DisplayBookingDetails();
        }

    }
}
