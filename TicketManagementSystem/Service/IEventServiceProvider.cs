using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Constants;
using TicketManagementSystem.Model;
using TicketManagementSystem.Repository;

namespace TicketManagementSystem.Service
{
    internal interface IEventServiceProvider
    {
        Event CreateEvent(string eventName, DateTime date, TimeSpan time, int totalSeats, decimal ticketPrice, EventTypes eventType, Venue venue);
        public List<Event> GetAllEvents();
        public int GetAvailableNoOfTickets(string eventName);
        public decimal CalculateBookingCost(int numTickets, decimal ticketPrice);
        public void BookTickets(string eventName, int numTickets, Customer[] arrayOfCustomer);
    }
}
