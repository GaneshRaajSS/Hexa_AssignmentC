using System;
using TicketManagementSystem.Constants;
using TicketManagementSystem.Model;
using TicketManagementSystem.Repository;
using TicketManagementSystem.Service;
namespace TicketManagementSystem
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            TicketBookingSystem ticketBookingSystem = new TicketBookingSystem();
            EventRepo eventRepo = new EventRepo();
            List<Booking> bookings = new List<Booking>();
            BookingRepo bookingRepo = new BookingRepo(eventRepo);
            bool FLAG = true;
            while (FLAG)
            {
                Console.WriteLine("Ticket Booking System");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Tickets");
                Console.WriteLine("4. Get Available Seats");
                Console.WriteLine("5. Display Events");
                Console.WriteLine("6. Booking Details");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateEvent(eventRepo);
                        AskToContinue(ref FLAG);
                        break;
                    case 2:
                        BookTickets(ticketBookingSystem,eventRepo,bookings);
                        AskToContinue(ref FLAG);
                        break;
                    case 3:
                        CancelTickets(ticketBookingSystem, eventRepo);
                        AskToContinue(ref FLAG);
                        break;
                    case 4:
                        var eve = eventRepo.GetAllEvents();
                        
                            foreach (var ev in eve)
                            {
                                Console.WriteLine($"Event: {ev.EventName}");
                            }

                        Console.Write("Enter event name: ");
                        string eventName = Console.ReadLine();
                        
                        int availableSeats = eventRepo.GetAvailableNoOfTickets(eventName);
                        Console.WriteLine($"Available seats for event '{eventName}': {availableSeats}");
                        AskToContinue(ref FLAG);
                        break;
                    case 5:
                        var allEvents = eventRepo.GetAllEvents();
                        if (allEvents != null && allEvents.Count > 0)
                        {
                            foreach (var ev in allEvents)
                            {
                                Console.WriteLine($"Event: {ev.EventName}\t Date: {ev.EventDate}\t Time: {ev.EventTime}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No events to display.");
                        }
                        Console.WriteLine("Want to continue Yes?No");
                        AskToContinue(ref FLAG);

                        break;
                    case 6:
                        Console.Write("Enter booking ID: ");
                        int bookingId = int.Parse(Console.ReadLine());
                        var bookingDetails = eventRepo.GetBookingDetails(bookingId);
                        if (bookingDetails != null)
                        {
                            Console.WriteLine($"Booking ID: {bookingDetails.BookingId}");
                            Console.WriteLine($"Event ID: {bookingDetails.EventId}");
                            Console.WriteLine($"Number of Tickets: {bookingDetails.NumTickets}");
                            Console.WriteLine($"Total Cost: {bookingDetails.TotalCost}");
                            Console.WriteLine($"Booking Date: {bookingDetails.BookingDate}");
                        }
                        else
                        {
                            Console.WriteLine($"Booking with ID {bookingId} not found.");
                        }
                        AskToContinue(ref FLAG);
                        break;
                    case 7:
                        FLAG = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void AskToContinue(ref bool flag)
        {
            Console.WriteLine("Want to continue? Yes/No");
            string cnn = Console.ReadLine();
            if (cnn.ToLower() == "no")
            {
                flag = false;
            }
        }
        static void CreateEvent(IEventServiceProvider eventService)
        {
     
            Console.WriteLine("Enter event details:");
            Console.Write("Event Name: ");
            string eventName = Console.ReadLine();
            Console.Write("Event Date (YYYY-MM-DD): ");
            DateTime eventDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Event Time (HH:MM): ");
            TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());

            Console.Write("Venue Id: ");
            int venueId = int.Parse(Console.ReadLine());

            Console.Write("Venue Name: ");
            string venueName = Console.ReadLine(); 

            Console.Write("Venue Address: ");
            string venueAddress = Console.ReadLine();
            Venue venue = new Venue(venueId,venueName, venueAddress);

            Console.Write("Total Seats: ");
            int totalSeats = int.Parse(Console.ReadLine());

            Console.Write("Ticket Price: ");
            decimal ticketPrice = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Select Event Type:");
            foreach (EventTypes eventType in Enum.GetValues(typeof(EventTypes)))
            {
                Console.WriteLine($"{(int)eventType}. {eventType}");
            }
            EventTypes selectedEventType = (EventTypes)int.Parse(Console.ReadLine());
            eventService.CreateEvent(eventName, eventDate, eventTime, totalSeats, ticketPrice, selectedEventType, venue);
            Console.WriteLine("Event created successfully.");
        }

        static void BookTickets(TicketBookingSystem ticketBookingSystem, EventRepo eventRepo,List<Booking> bookings)
        {
            Event selectedEvent = DisplayEventsAndGetSelection(eventRepo);
            if (selectedEvent == null) return;
            int numTickets = GetNumberOfTicketsFromUser();
            Customer[] arrayOfCustomer = CustomerRepo.GetCustomers(numTickets);
            ticketBookingSystem.BookTickets(selectedEvent, eventRepo, numTickets, arrayOfCustomer, bookings);
        }
        static void CancelTickets(TicketBookingSystem ticketBookingSystem, EventRepo eventRepo)
        {
            Event selectedEvent = DisplayEventsAndGetSelection(eventRepo);
            int numTickets = GetNumberOfTicketsFromUser();
            ticketBookingSystem.CancelTickets(selectedEvent,eventRepo ,numTickets);
        }

        public static Event DisplayEventsAndGetSelection(EventRepo eventRepo)
        {
            Console.WriteLine("Available Events:");
            var events=eventRepo.GetAllEvents();
            if (events == null || events.Count == 0)
            {
                Console.WriteLine("No events available.");
                return null;
            }

            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {events[i].EventName}");
            }

            int selectedOption = -1;
            while (selectedOption < 1 || selectedOption > events.Count)
            {
                Console.Write("Enter the number of the event: ");
                if (int.TryParse(Console.ReadLine(), out selectedOption) && selectedOption > 0 && selectedOption <= events.Count)
                {
                    return events[selectedOption - 1];
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please enter a valid number.");
                }
            }

            return null;
        }

        private static int GetNumberOfTicketsFromUser()
        {
            Console.Write("Enter the number of tickets you want to book: ");
            int numTickets = int.Parse(Console.ReadLine());
            if (numTickets <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number greater than 0.");
            }

            return numTickets;
        }

        //#region Events
        //List<Event> events = new List<Event>()
        //    {
        //        new Event(){EventName= "Movie Night",EventDate= new DateOnly(2024, 5, 15),EventTime= new TimeOnly(18, 30, 0),VenueName="Cinema Hall 1", TotalSeats=300,AvailableSeats = 100,TicketPrice= 150.00M ,EventTypes = EventTypes.Movie },
        //        new Event(){EventName="Cricket Match", EventDate=new DateOnly(2024, 6, 20), EventTime=new TimeOnly(19, 0, 0),VenueName= "Stadium",TotalSeats= 5000, AvailableSeats = 2000,TicketPrice= 8000.00M ,EventTypes =EventTypes.Sports},
        //        new Event(){EventName="Concert", EventDate=new DateOnly(2024, 7, 10), EventTime= new TimeOnly(20, 0, 0), VenueName="Outdoor Arena",TotalSeats= 2000,AvailableSeats = 500, TicketPrice= 999.00M ,EventTypes =EventTypes.Concert}
        //    };
        //foreach (Event e in events)
        //{
        //    eventRepoObj.DisplayEventDetails();
        //}

        //Event eventToBook = events[2];

        ////Calculate_total_revenue()
        //decimal totalRevenue = 0;
        //foreach (Event e in events)
        //{
        //    decimal revenue = eventRepoObj.CalculateTotalRevenue(e, e.TotalSeats - e.AvailableSeats);
        //    totalRevenue += revenue;

        //}
        //Console.WriteLine($"Total Revenue: {totalRevenue}");

        ////getBookedNoOfTickets()
        //Console.WriteLine($"Total Number of tickets booked:{eventRepoObj.GetBookedNumberOfTickets(eventToBook)}");

        ////book_tickets(num_tickets)
        //int numTicketsToBook = 5;
        //eventRepoObj.BookTickets(eventToBook, numTicketsToBook);
        //int bookedTickets = numTicketsToBook;
        //Console.WriteLine($"Number of tickets Booked  for {eventToBook.EventName}: {bookedTickets}\n");

        ////display_event_details()
        //foreach (Event e in events)
        //{
        //    eventRepoObj.DisplayEventDetails();
        //}

        ////cancel_booking(num_tickets)
        //eventRepoObj.CancelBooking(eventToBook, numTicketsToBook);

        //bookedTickets -= numTicketsToBook;
        //Console.WriteLine($"Booked tickets after cancellation for {eventToBook.EventName}: {bookedTickets}");

        //#endregion
        //#region Venue
        //List<Venue> venues = new List<Venue>()
        //    {
        //        new Venue(){VenueName="PVR Cinemas",VenueAddress="Chennai"},
        //        new Venue(){VenueName="M.A.Chidambaram",VenueAddress = "Chennai"},
        //        new Venue(){VenueName="YMCA Nandhanam",VenueAddress = "Chennai"}
        //    };
        //foreach (Venue v in venues)
        //{
        //    VenueRepo.DisplayVenueDetails(v);
        //}
        //#endregion
        //#region Customer
        //List<Customer> customers = new List<Customer>()
        //    {
        //        new Customer(){CustomerName="Ganesh",CustomerMailId="ganesh@gmail.com",CustomerPhoneNumber=1234567890},
        //        new Customer(){CustomerName="Raaj",CustomerMailId="Raaj@gmail.com",CustomerPhoneNumber=9876543210},
        //        new Customer(){CustomerName="Raha",CustomerMailId="Raha@gmail.com",CustomerPhoneNumber=3546123782}
        //    };
        //foreach (Customer c in customers)
        //{
        //    CustomerRepo.DisplayCustomerDeatils(c);
        //}
        //#endregion
        //#region Booking

        //decimal totalCost = bookingRepoObj.CalculateBookingCost(numTicketsToBook, eventToBook.TicketPrice);
        //Console.WriteLine($"Total booking cost: {totalCost}");

        //// Book a specified number of tickets for an event
        //bookingRepoObj.BookTickets(numTicketsToBook, eventToBook, eventRepoObj);

        ////display_event_details()
        //foreach (Event e in events)
        //{
        //    eventRepoObj.DisplayEventDetails();
        //}

        //// Cancel the booking and update the available seats
        //bookingRepoObj.CancelBooking(numTicketsToBook, eventToBook, eventRepoObj);
        //#endregion
    }
}



