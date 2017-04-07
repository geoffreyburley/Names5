using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace names5.ViewModels
{
    public class VMNameAddress
    {
        //Properties.

        public int NameId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int FatherId { get; set; }
        public int MotherId { get; set; }
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string PostalCode { get; set; }

    }
}
