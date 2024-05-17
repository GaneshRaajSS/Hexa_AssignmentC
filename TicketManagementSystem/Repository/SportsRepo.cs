using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Model;

namespace TicketManagementSystem.Repository
{
    internal class SportsRepo
    {
        public void DisplayEventDetails(Sports sports)
        {
            Console.WriteLine($"Sport: {sports.SportsName}");
            Console.WriteLine($"Teams: {sports.TeamName}");
            EventRepo eventRepo = new EventRepo();
            eventRepo.GetEvents();
        }
    }
}
