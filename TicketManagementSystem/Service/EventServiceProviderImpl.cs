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
    internal interface EventServiceProviderImpl:IEventServiceProvider
    {
        public Event CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, EventTypes eventType)
        {
            switch (eventType)
            {
                case EventTypes.Movie:
                    return new Movie(eventName, eventDate, eventTime, venue, totalSeats, totalSeats, ticketPrice, eventType, MovieGenre.Action, "ActorName", "ActressName");
                case EventTypes.Sports:
                    return new Sports(eventName, eventDate, eventTime, venue, totalSeats, totalSeats, ticketPrice, eventType, "sportsName", "teamName");
                case EventTypes.Concert:
                    return new Concert(eventName, eventDate, eventTime, venue, totalSeats, totalSeats, ticketPrice, eventType, "artist", ConcertType.Theatrical);
                default:
                    throw new ArgumentException($"Invalid event type: {eventType}");
            }
        }
        
        public decimal CalculateTotalRevenue(Event eventObj, int numTickets)
        {
            return eventObj.TicketPrice * numTickets;
        }
        public int GetBookedNumberOfTickets(Event eventObj)
        {
            return eventObj.TotalSeats - eventObj.AvailableSeats;
        }

        //public void BookTickets(Event eventObj, EventRepo eventRepo, int numTickets, Customer[] arrayOfCustomer, List<Booking> bookings)
        //{
        //    Event selectedEvent = eventRepo.GetEvents().FirstOrDefault(evt => evt.EventName == eventObj.EventName);

        //    if (selectedEvent == null)
        //    {
        //        Console.WriteLine($"Event '{eventObj.EventName}' not found.");
        //        return;
        //    }

        //    if (selectedEvent.AvailableSeats < numTickets)
        //    {
        //        Console.WriteLine($"Sorry, only {selectedEvent.AvailableSeats} tickets are available for '{eventObj.EventName}'.");
        //        return;
        //    }

        //    var customers = new List<Customer>(arrayOfCustomer);
        //    decimal totalCost = selectedEvent.TicketPrice * numTickets;
        //    var booking = new Booking(customers.ToArray(), selectedEvent, numTickets, totalCost, DateTime.Now);
        //    bookings.Add(booking);

        //    selectedEvent.AvailableSeats -= numTickets;

        //    Console.WriteLine($"{numTickets} tickets successfully booked for '{eventObj.EventName}'.");
        //}

        public void CancelBooking(Event eventObj, int numTickets)
        {
            if (numTickets <= (eventObj.TotalSeats - eventObj.AvailableSeats))
            {
                eventObj.AvailableSeats += numTickets;
                Console.WriteLine($"Successfully canceled {numTickets} ticket(s) for {eventObj.EventName}.");
            }
            else
            {
                Console.WriteLine($"Failed to cancel {numTickets} ticket(s) for {eventObj.EventName}. Invalid number of tickets to cancel.");
            }
        }


    }
}
