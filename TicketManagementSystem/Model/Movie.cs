using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Constants;

namespace TicketManagementSystem.Model
{
    internal class Movie:Event
    {
        MovieGenre genre;
        string actorName;
        string actressName;

        public MovieGenre Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public string ActorName
        {
            get { return actorName; }
            set { actorName = value; }
        }
        public string ActressName
        {
            get { return actressName; }
            set { actressName = value; }
        }
        public Movie() : base()
        {
            
        }
        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime,Venue venue, int totalSeats, int availableSeats, decimal ticketPrice,EventTypes eventTypes, MovieGenre genre, string actorName, string actressName) 
            :base(eventName,  eventDate,  eventTime,venue,  totalSeats,  availableSeats,  ticketPrice, eventTypes)
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }


        public override decimal CalculateTotalRevenue(int numTickets)
        {
            return TicketPrice * numTickets;
        }

        public override int GetBookedNumberOfTickets()
        {
            return TotalSeats - AvailableSeats;
        }

        public override void BookTickets(int numTickets)
        {
            if (numTickets <= AvailableSeats)
            {
                AvailableSeats -= numTickets;
                Console.WriteLine($"Successfully booked {numTickets} ticket(s) for {EventName}.");
            }
            else
            {
                Console.WriteLine($"Failed to book {numTickets} ticket(s) for {EventName}. Insufficient seats available.");
            }
        }

        public override void CancelBooking(int numTickets)
        {
            if (numTickets <= (TotalSeats - AvailableSeats))
            {
                AvailableSeats += numTickets;
                Console.WriteLine($"Successfully canceled {numTickets} ticket(s) for {EventName}.");
            }
            else
            {
                Console.WriteLine($"Failed to cancel {numTickets} ticket(s) for {EventName}. Invalid number of tickets to cancel.");
            }
        }

        public override int GetAvailableNoOfTickets()
        {
            return AvailableSeats;
        }

        public override Event CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, EventTypes eventType)
        {
            return new Movie(eventName, eventDate, eventTime, venue, totalSeats, totalSeats, ticketPrice, eventType, MovieGenre.Action, "ActorName", "ActressName");
        }
    }
}
