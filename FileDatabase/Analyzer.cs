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
        //public void AnalyzeCartItems()
        //{
        //    var customers = new CustomerDAO().GetCustomers();

        //    foreach( Customer customer in customers )
        //    {
        //        foreach( string cartItem in customer.CartItems )
        //        {
        //            if( cartItem.Equals( "cookies" ) )
        //            {
        //                Console.WriteLine(customer.Name + " has cookies in his cart.");
        //                break;
        //            }
        //        }
        //    }
        //}

        public ICustomerDAO ICustomerDAO { get; set; }

        public Analyzer( ICustomerDAO customerDAO )
        {
            ICustomerDAO = customerDAO;
        }

        public void AnalyzeCartItems()
        {
            var customers = ICustomerDAO.GetCustomers();

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
