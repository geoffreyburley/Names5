using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using names5.Models;
using names5.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace names5.API
{
    [Route("api/[controller]")]
    public class AddressesController : Controller
    {
        //===============================================
        //Fields.
        private ApplicationDbContext _db;
        //===============================================
        //Properties.
        
        //===============================================
        //Constructor().
        //===============================================
        public AddressesController (ApplicationDbContext db)
        {
            _db = db;
        }
        //===========================================
        //Methods().
        //===========================================
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //===========================================
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {   
            //Return one address.
            Address addressOfInterest = (from a in _db.Addresses
                                         where a.Id == id
                                         select new Address
                                         {
                                             Id = a.Id,
                                             AddressType = a.AddressType,
                                             StreetAddress = a.StreetAddress,
                                             City = a.City,
                                             StateName = a.StateName,
                                             PostalCode = a.PostalCode
                                         }).FirstOrDefault();
            if (addressOfInterest != null)
            {
                return Ok(addressOfInterest);
            }
            else
            {
                return NotFound();
            }

        }
        //===========================================
        // Post an address to the the addresses table.
        [HttpPost]
        public IActionResult Post([FromBody]Address address)
        {
            Address addressToAdd = new Address
            {
                Id = address.Id,
                AddressType = address.AddressType,
                StreetAddress = address.StreetAddress,
                City = address.City,
                StateName = address.StateName,  
                PostalCode = address.PostalCode,
                NameAddresses = address.NameAddresses               
                
            };
            if(addressToAdd != null)
            {
                if (addressToAdd.Id == 0)
                {
                    _db.Addresses.Add(addressToAdd);
                    _db.SaveChanges();
                    return Ok(addressToAdd);
                }
                else {
                    _db.Addresses.Update(addressToAdd);
                    _db.SaveChanges();

                    return Ok(addressToAdd);
                }
            }
            else
            {
                return BadRequest();
            }

        }

        //===========================================
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        //===========================================
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Address addressToDelete = (from a in _db.Addresses
                                      where id == a.Id
                                      select a).FirstOrDefault();
            if (addressToDelete != null)
            {
                _db.Addresses.Remove(addressToDelete);
                _db.SaveChanges();
                return Ok(addressToDelete);

            }
            else
            {
                return NotFound();
            }
        }
        //===========================================
    }
}
