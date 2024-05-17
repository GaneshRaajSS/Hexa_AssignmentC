using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Constants;
using TicketManagementSystem.Repository;

namespace TicketManagementSystem.Model
{
    internal abstract class BookingSystem
    {
        public abstract void DisplayEventDetails(Event eventObj, EventRepo eventRepo);
        public abstract void BookTickets(Event eventObj, EventRepo eventRepo, int numTickets, Customer[] arrayOfCustomer, List<Booking> bookings);
        public abstract void CancelTickets(Event eventObj, EventRepo eventRepo, int numTickets);
    }
}
