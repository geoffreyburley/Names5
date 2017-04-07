﻿using System;
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
    public class NameAddressesController : Controller
    {
        //=====================================================
        //Fields.
        //=====================================================
        private ApplicationDbContext _db;
        //=====================================================
        //Properties.
        //=====================================================
        //Constructor().
        //=====================================================
        public NameAddressesController (ApplicationDbContext db)
        {
            _db = db;
        }
        //=====================================================
        //Methods.
        //=====================================================
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //=====================================================
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        //======================================================
        // Add a new name, an address and a nameaddress.
        [HttpPost]
        public IActionResult Post([FromBody]VMNameAddress vmnameaddress)
        {
            Name nameToAdd = new Name
            {
                Id = vmnameaddress.NameId,
                FirstName = vmnameaddress.FirstName,
                LastName = vmnameaddress.LastName,
                DateOfBirth = vmnameaddress.DateOfBirth,
                FatherId = vmnameaddress.FatherId,
                MotherId = vmnameaddress.MotherId
            };
            Address addressToAdd = new Address
            {
                Id = vmnameaddress.AddressId,
                AddressType = vmnameaddress.AddressType,
                StreetAddress = vmnameaddress.StreetAddress,
                City = vmnameaddress.City,
                StateName = vmnameaddress.StateName,
                PostalCode = vmnameaddress.PostalCode
            };
            if (nameToAdd != null)
            {
                if (nameToAdd.Id == 0)
                {
                    _db.Names.Add(nameToAdd);
                    _db.SaveChanges();
                    
                }
                if (addressToAdd != null)
                {

                    _db.Addresses.Add(addressToAdd);
                    _db.SaveChanges();
                  
                    NameAddress nameaddress = new NameAddress
                    {
                        NameId = nameToAdd.Id,
                    //  Name = nameToAdd,
                        AddressId = addressToAdd.Id,
                    //  Address = addressToAdd
                    };
                    _db.NameAddresses.Add(nameaddress);
                    _db.SaveChanges();
                    return Ok(nameaddress);
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
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        //=====================================================
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        //=====================================================

    }
}
