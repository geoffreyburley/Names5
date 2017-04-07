using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace names5.Models
{
    public class Name
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int FatherId { get; set; }
        public int MotherId { get; set; }
        public ICollection<NameAddress> NameAddresses { get; set;}

    }
}
