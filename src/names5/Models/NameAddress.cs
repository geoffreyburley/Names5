using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace names5.Models
{
    public class NameAddress
    {
        public int NameId { get; set; }
        public Name Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}
