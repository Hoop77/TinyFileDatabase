using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    public class Analyzer
    {
        // BAD:
        public void AnalyzeCartItems()
        {
            var customers = new CustomerDAO().GetCustomers();
            
            foreach( Customer customer in customers )
            {
                foreach( string cartItem in customer.CartItems )
                {
                    if( cartItem.Equals( "cookies" ) )
                    {
                        Console.WriteLine(customer.Name + " has cookies in his cart.");
                        break;
                    }
                }
            }
        }

        // GOOD:
        public void AnalyzeCartItems( ICustomerDAO customerDAO )
        {
            var customers = customerDAO.GetCustomers();

            foreach( Customer customer in customers )
            {
                foreach( string cartItem in customer.CartItems )
                {
                    if( cartItem.Equals( "cookies" ) )
                    {
                        Console.WriteLine( customer.Name + " has cookies in his cart." );
                        break;
                    }
                }
            }
        }
    }
}
