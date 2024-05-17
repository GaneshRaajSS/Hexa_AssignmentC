using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Model;

namespace TicketManagementSystem.Repository
{
    internal class CustomerRepo
    {
        public static Customer[] GetCustomers(int numTickets)
        {
            Customer[] arrayOfCustomer = new Customer[numTickets];

            for (int i = 0; i < numTickets; i++)
            {
                Console.WriteLine($"Enter details for Customer {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Phone Number: ");
                long phoneNumber = long.Parse(Console.ReadLine());

                arrayOfCustomer[i] = new Customer(name, email, phoneNumber);
            }

            return arrayOfCustomer;
        }
        public static void DisplayCustomerDeatils(Customer c)
        {

            Console.WriteLine($"Customer Name: {c.CustomerName}\n" +
                $"Customer MailId: {c.CustomerMailId}\n" +
                $"Customer Phone Number: {c.CustomerPhoneNumber}\n");

        }
    }
}
