using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using names5.Data;
using names5.Models;
using names5.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace names5.API
{
    
    [Route("api/[controller]")]
    public class NamesController : Controller
    {   //======================================================
        //Fields.
        //======================================================
        private ApplicationDbContext _db;
        //======================================================
        //Properties.
        //======================================================


        //======================================================
        //Constructor().
        //======================================================
        public NamesController (ApplicationDbContext db) {
            _db = db;
        }
        //======================================================
        //Methods().
        //======================================================
        // Get all names.
        [HttpGet]
        public List<Name> Get()
        {
            List<Name> names = (from n in _db.Names
                                select new Name
                                {   Id = n.Id,
                                    FirstName = n.FirstName,
                                    LastName = n.LastName,
                                    DateOfBirth = n.DateOfBirth,
                                    FatherId = n.FatherId,
                                    MotherId =n.MotherId,
                                    NameAddresses = (from na in n.NameAddresses
                                                     select new NameAddress
                                                     {
                                                         Address = na.Address
                                                     }).ToList()
                                }).ToList();
            return names;
        }

        //======================================================
        // Gett one name. 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Name name = (from n in _db.Names
                         where n.Id == id
                         select new Name {
                             Id= n.Id,
                             FirstName = n.FirstName,
                             LastName = n.LastName,
                             DateOfBirth = n.DateOfBirth,
                             FatherId = n.FatherId,
                             MotherId = n.MotherId,
                             NameAddresses =(from na in n.NameAddresses
                                             select new NameAddress{
                                                    Address = na.Address
                                             }).ToList()
                         }).FirstOrDefault();
            if (name != null)
            {
                return Ok(name);
            }
            else
            {
                return NotFound();
            }
        }
        //======================================================
        // Update a name.  
        [HttpPost]
        public IActionResult Post([FromBody]Name name) {

            Name nameToUpdate = new Name
            {
                Id = name.Id,
                FirstName = name.FirstName,
                LastName = name.LastName,
                DateOfBirth = name.DateOfBirth,
                MotherId = name.MotherId,
                FatherId = name.FatherId

            };
            if (nameToUpdate != null)
            {
                if (nameToUpdate.Id != 0)
                {
                    _db.Names.Update(nameToUpdate);
                    _db.SaveChanges();
                    return Ok(nameToUpdate);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
            
        }
        //======================================================
        //// Add a new name, an address and a nameaddress.
        //[HttpPost]
        //public IActionResult Post([FromBody]VMNameAddress vmnameaddress)
        //{
        //    Name nameToAdd = new Name
        //    {
        //        Id = vmnameaddress.NameId,
        //        FirstName = vmnameaddress.FirstName,
        //        LastName = vmnameaddress.LastName,
        //        DateOfBirth = vmnameaddress.DateOfBirth,
        //        FatherId = vmnameaddress.FatherId,
        //        MotherId = vmnameaddress.MotherId


        //    };
        //    Address addressToAdd = new Address
        //    {
        //        Id = vmnameaddress.AddressId,
        //        AddressType = vmnameaddress.AddressType,
        //        StreetAddress = vmnameaddress.StreetAddress,
        //        City = vmnameaddress.City,
        //        StateName = vmnameaddress.StateName,
        //        PostalCode = vmnameaddress.PostalCode


        //    };


        //    if (nameToAdd != null)
        //    {


        //        _db.Names.Add(nameToAdd);
        //        _db.SaveChanges();
        //        if (addressToAdd != null)
        //        {
        //            _db.Addresses.Add(addressToAdd);
        //            _db.SaveChanges();
        //            NameAddress nameaddress = new NameAddress
        //            {
        //                NameId = nameToAdd.Id,
        //                Name = nameToAdd,
        //                AddressId = addressToAdd.Id,
        //                Address = addressToAdd
        //            };
        //            _db.NameAddresses.Add(nameaddress);
        //            _db.SaveChanges();
        //            return Ok(nameToAdd);

        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }

        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //}
        
        //======================================================
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        //======================================================
        // Delete a name and it's links in the link table.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Name name = (from n in _db.Names
                         where n.Id == id
                         select n).FirstOrDefault();
            if (name != null)
            {
                _db.Names.Remove(name);
                _db.SaveChanges();
                foreach (NameAddress naToTest in _db.NameAddresses)
                {
                    if (id == naToTest.NameId)
                    {
                        _db.NameAddresses.Remove(naToTest);
                        _db.SaveChanges();
                    }
                }
                return Ok(name);
            }
            else
            {
                return NotFound();
            }
        }
        //======================================================
    }
}
