using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    public class CustomerDAO : ICustomerDAO
    {
        public static void Foo() { }

        public ArrayList GetCustomers()
        {
            var customers = new ArrayList();
            var entries = new Database().ReadEntriesFromFile( @"Database.txt" );

            foreach( Entry entry in entries )
            {
                if( entry.Name.Equals( "customer" ) )
                    customers.Add( processAttributes( entry ) );
            }

            return customers;
        }

        private Customer processAttributes( Entry entry )
        {
            var customer = new Customer();
            customer.CartItems = new ArrayList();

            foreach( Attribute attribute in entry.Attributes )
            {
                if( attribute.Name.Equals( "id" ) )
                    customer.Id = Convert.ToInt64( attribute.Value );
                else if( attribute.Name.Equals( "name" ) )
                    customer.Name = attribute.Value;
                else if( attribute.Name.Equals( "cartItem" ) )
                    customer.CartItems.Add( attribute.Value );
            }

            return customer;
        }
    }
}
