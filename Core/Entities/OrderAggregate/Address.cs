using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    /*Address owned by our Order
     * which means it going to live in the same raw of our table as the order it self
     * its not going to be related to the order in anyway
     * */
    public class Address
    {
        public Address() //for EntityFrameWork, and avoid any complains when adding a new migration
        {
        }

        public Address(string? firstName, string? lastName, string? street, string? city, string? state, string? zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
