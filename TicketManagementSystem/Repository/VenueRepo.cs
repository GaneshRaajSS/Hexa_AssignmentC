using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Model;

namespace TicketManagementSystem.Repository
{
    internal class VenueRepo
    {
        public static void DisplayVenueDetails(Venue v)
        {
            Console.WriteLine($"Veneue Name: {v.VenueName}\n" +
                $"Veneue Address: {v.VenueAddress}\n ");
        }
    }
}
