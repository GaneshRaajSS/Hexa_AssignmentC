using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Model;
using TicketManagementSystem.Repository;

namespace TicketManagementSystem.Service
{
    internal interface IBookingSystemServiceProvider
    {
        public decimal CalculateBookingCost(int numTickets, decimal ticketPrice);
        public void BookTickets(Event eventObj, EventRepo eventRepo, int numTickets, Customer[] arrayOfCustomer, List<Booking> bookings);
        public void CancelBooking(int numTickets, Event eventObj, EventRepo eventRepo);
    }
}
