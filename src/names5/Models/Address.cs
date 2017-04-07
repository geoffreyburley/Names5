using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace names5.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressType { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string PostalCode { get; set; }
        public ICollection<NameAddress> NameAddresses { get; set; }

    }
}
