using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Model;
using TicketManagementSystem.Repository;

namespace TicketManagementSystem.Service
{
    internal interface BookingSystemServiceProviderImpl:EventServiceProviderImpl,IBookingSystemServiceProvider
    {
        public decimal CalculateBookingCost(int numTickets, decimal ticketPrice)
        {
            return numTickets * ticketPrice;
        }

        public void BookTickets(EventRepo eventRepo,string eventName, int numTickets, Customer[] arrayOfCustomer)
        {
            eventRepo.BookTickets(eventName, numTickets, arrayOfCustomer);
        }

        public void CancelBooking(EventRepo eventRepo,int bookingId)
        {
            eventRepo.CancelBooking(bookingId);
        }

    }
}
