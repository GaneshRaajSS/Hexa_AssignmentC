using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Model;

namespace TicketManagementSystem.Repository
{
    internal class MovieRepo
    {
        public void GetEvents(Movie movie, EventRepo eventRepo)
        {
            Console.WriteLine($"Genre: {movie.Genre}");
            Console.WriteLine($"Actor: {movie.ActorName}");
            Console.WriteLine($"Actress: {movie.ActressName}");
        }
    }
}
