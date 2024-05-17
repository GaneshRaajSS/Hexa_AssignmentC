using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Model
{
    public class Venue
    {
        int venueId;
        string venueName;
        string venueAddress;

        public int VenueId
        {
            get { return venueId; }
            set { venueId = value; }
        }
        public string VenueName
        {
            get {  return venueName; } 
            set {  venueName = value; }
        }
        public string VenueAddress
        {
            get { return venueAddress; }
            set { venueAddress = value; }
        }

        public Venue() { }

        public Venue(int venueId ,string venueName,string venueAddress) 
        {
            VenueId = venueId;
            VenueName = venueName;
            VenueAddress = venueAddress;
        }
    }
}
