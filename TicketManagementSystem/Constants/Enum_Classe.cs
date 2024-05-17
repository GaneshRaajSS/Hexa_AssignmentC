using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Constants
{
    public enum EventTypes
    {
        Movie = 1, 
        Sports, 
        Concert
    }

    internal enum MovieGenre
    {
        Action = 1,
        Comedy,
        Horror
    }

    internal enum ConcertType
    {
        Theatrical=1,
        Classical,
        Rock, 
        Recital
    }
}
