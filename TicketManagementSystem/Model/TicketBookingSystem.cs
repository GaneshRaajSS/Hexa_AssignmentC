using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Constants;
using TicketManagementSystem.Repository;

namespace TicketManagementSystem.Model
{
    internal class TicketBookingSystem : BookingSystem
    {
       
        public override void DisplayEventDetails(Event eventObj, EventRepo eventRepo)
        {
            eventRepo.GetEvents();
        }

        public override void BookTickets(Event eventObj, EventRepo eventRepo, int numTickets, Customer[] arrayOfCustomer, List<Booking> bookings)
        {
            eventRepo.BookTickets(eventObj.EventName, numTickets, arrayOfCustomer);
        }


        public override void CancelTickets(Event eventObj, EventRepo eventRepo, int bookingId)
        {
            eventRepo.CancelBooking(bookingId);
        }

        public static void TicketAvailChecker(Event selectedEvent)
        {
            int availTickets = selectedEvent.AvailableSeats;
            Console.Write("Enter number of tickets to book: ");
            int noOfBookingTickets = int.Parse(Console.ReadLine());
            if (availTickets >= noOfBookingTickets && availTickets > 0)
            {
                Console.WriteLine($"{noOfBookingTickets} Tickets are available for booking.\n");
            }
            else if (availTickets == 0)
            {
                Console.WriteLine("Sorry, Tickets are sold out.\n");
            }
            else
            {
                Console.WriteLine($"Only {availTickets} tickets are available, cannot book {noOfBookingTickets} tickets.\n");
            }
        }
    }
}
