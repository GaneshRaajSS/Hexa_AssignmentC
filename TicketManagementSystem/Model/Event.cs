using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Constants;

namespace TicketManagementSystem.Model
{
    internal abstract class Event
    {
        string eventName;
        DateTime eventDate;
        TimeSpan eventTime;
        Venue venue;
        int totalSeats;
        int availableSeats;
        decimal ticketPrice;
        EventTypes eventType;
        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }
        }
        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; }
        }
        public TimeSpan EventTime
        {
            get { return eventTime; }
            set { eventTime = value; }
        }
        public Venue Venue
        {
            get { return venue; }
            set { venue = value; }
        }
        public int TotalSeats
        {
            get { return totalSeats; }
            set { totalSeats = value; }
        }
        public int AvailableSeats
        {
            get { return availableSeats; }
            set { availableSeats = value; }
        }
        public decimal TicketPrice
        {
            get { return ticketPrice; }
            set { ticketPrice = value; }
        }
        public EventTypes EventTypes
        {
            get { return eventType; }
            set { eventType = value; }
        }

        public Event()
        { }
        public Event(string eventName, DateTime eventDate, TimeSpan eventTime,Venue venue, int totalSeats, int availableSeats, decimal ticketPrice, EventTypes eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = availableSeats;
            TicketPrice = ticketPrice;
            EventTypes = eventType;
        }

        public abstract decimal CalculateTotalRevenue(int numTickets);
        public abstract int GetBookedNumberOfTickets();
        public abstract void BookTickets(int numTickets);
        public abstract void CancelBooking(int numTickets);
        public abstract int GetAvailableNoOfTickets();
        public abstract Event CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, EventTypes eventType);

        public override string ToString()
        {
            return $"Event Name: {EventName}\n" +
                        $"Event Date: {EventDate}\n" +
                        $"Event Time: {EventTime}\n" +
                        $"Venue Name: {Venue.VenueName}\n" +
                        $"Venue Address: {Venue.VenueAddress}\n" +
                        $"Total Seats: {TotalSeats}\n" +
                        $"Available Seats: {AvailableSeats}\n" +
                        $"Ticket Price: {TicketPrice}\n" +
                        $"Event Types: {EventTypes}\n";
        }

    }
}
