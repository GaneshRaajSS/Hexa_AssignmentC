using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Constants;

namespace TicketManagementSystem.Model
{
    internal class Sports:Event
    {
        string sportName;
        string teamsName;

        public string SportsName
        {
            get { return sportName; }
            set { sportName = value; }
        }
        public string TeamName
        {
            get { return teamsName; }
            set { teamsName = value; }
        }
        public Sports():base()
        {
            
        }
        public Sports(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, int availableSeats, Decimal ticketPrice, EventTypes eventType, string sportsName, string teamName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, availableSeats, ticketPrice, eventType)
        {
            SportsName = sportsName;
            TeamName = teamName;
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
            return new Sports(eventName, eventDate, eventTime, venue, totalSeats, totalSeats, ticketPrice, eventType, "sportsName", "teamName");
        }
    }
}
