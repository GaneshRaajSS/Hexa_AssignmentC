using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Constants;
using TicketManagementSystem.Model;

namespace TicketManagementSystem.Repository
{
    internal class ConcertRepo
    {
        public void DisplayEventDetails(EventRepo eventRepo,Concert concert)
        {
            
            Console.WriteLine($"Artist: {concert.Artist}");
            Console.WriteLine($"Type: {concert.Type}");
        }
    }
}
