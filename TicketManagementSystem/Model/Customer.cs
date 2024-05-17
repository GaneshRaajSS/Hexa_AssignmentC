using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Model
{
    internal class Customer
    {

        string customerName;
        string customerMailId;
        long customerPhoneNumber;
        

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string CustomerMailId
        {
            get { return customerMailId; }
            set { customerMailId = value; }
        }
        public long CustomerPhoneNumber
        {
            get { return customerPhoneNumber; }
            set { customerPhoneNumber = value; }
        }

        public Customer() { }
        public Customer(string customerName, string customerMailId, long customerPhoneNumber)
        {
            CustomerName = customerName;
            CustomerMailId = customerMailId;
            CustomerPhoneNumber = customerPhoneNumber;
        }
    }
}
