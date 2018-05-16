#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheEviction.Entities.Models;
using TheEviction.Entities.ViewModels;
#endregion

namespace TheEviction.Controllers.ClientRequest
{
    public class ClientController : Controller
    {
        private readonly EvictionDevContext _context;
        private readonly IClientRepository _repository;

        public ClientController(EvictionDevContext context, IClientRepository repository)
        {
            _context = context;
            _repository = repository;
        }
      
        //GET: Client Data TEST
        public IActionResult Index()
        {
            try
            {
                // it is the responsibility of the Controller to prepare the data for the view.
                var client = _repository.GetTopClientDataTables();
                ViewBag.Title = "Client Search";
                return View(client);
            }
            catch (Exception ex)
            {
                //Logging to the console.
                return Redirect("/error");
            }

        }

        // GET: Client
        //public async Task<IActionResult> Index()
        //{
        //    var evictionDevContext = _context.Client.Include(c => c.Address).Include(c => c.CompanyType).Include(c => c.Contact).Include(c => c.County).Include(c => c.Facility).Include(c => c.Phone);
        //    return View(await evictionDevContext.ToListAsync());
        //}

        // GET: Client/CreateClient
        public IActionResult CreateClient()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressLine1");
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyType, "CompanyTypeId", "CompanyTypeName");
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "ContactName");
            ViewData["CountyId"] = new SelectList(_context.County, "CountyId", "CountyName");
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName");
            ViewData["PhoneId"] = new SelectList(_context.Phone, "PhoneId", "PhoneNum");
            //return View();
            return PartialView("CreateClient");

        }

        // GET: Client/Create
        public IActionResult Create()
        {
            var newClient = new Client();

            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressLine1");
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyType, "CompanyTypeId", "CompanyTypeName");
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "ContactName");
            ViewData["CountyId"] = new SelectList(_context.County, "CountyId", "CountyName");
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName");
            ViewData["PhoneId"] = new SelectList(_context.Phone, "PhoneId", "PhoneNum");
            return View(Mapper.Map<ClientViewModel>(newClient));
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ClientNum,ClientName,CompanyTypeId,FacilityId,AddressId,ContactId,PhoneId,CountyId,Notes,IsActiveFlg,IsOfficeAccessFlg")] ClientViewModel theClient)
        {
            // Calling an API is no different than calling a POST that results in a view.
            // Use Automapper to switch from ClientViewModel to Client, ultimately we can't save the ViewModel to the database, we wanna convert into an actual Client object that we can store to the db.
            if (ModelState.IsValid)
            {
                var newClient = Mapper.Map<Client>(theClient); // we want a Client object, and we want to pass in the theClient

                _context.Add(newClient);
                await _context.SaveChangesAsync();
                //When we are done saving to the database.
                return RedirectToAction(nameof(Index), Mapper.Map<ClientViewModel>(newClient));
            }
            //if ModelState is Invalid
            // InvalidOperationException: The model item passed into the ViewDataDictionary is of type 'TheEviction.Entities.ViewModels.ClientViewModel', but this ViewDataDictionary instance requires a model item of type 'TheEviction.Entities.Models.Client'.
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressLine1", theClient.AddressId);
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyType, "CompanyTypeId", "CompanyTypeName", theClient.CompanyTypeId);
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "ContactName", theClient.ContactId);
            ViewData["CountyId"] = new SelectList(_context.County, "CountyId", "CountyName", theClient.CountyId);
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName", theClient.FacilityId);
            ViewData["PhoneId"] = new SelectList(_context.Phone, "PhoneId", "PhoneNum", theClient.PhoneId);
            ViewBag.Foo = "Client/Create Route";
            return View(Mapper.Map<Client>(theClient));
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.SingleOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressLine1", client.AddressId);
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyType, "CompanyTypeId", "CompanyTypeName", client.CompanyTypeId);
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "ContactName", client.ContactId);
            ViewData["CountyId"] = new SelectList(_context.County, "CountyId", "CountyName", client.CountyId);
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName", client.FacilityId);
            ViewData["PhoneId"] = new SelectList(_context.Phone, "PhoneId", "PhoneNum", client.PhoneId);
            return View(client);
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Include(c => c.Address)
                .Include(c => c.CompanyType)
                .Include(c => c.Contact)
                .Include(c => c.County)
                .Include(c => c.Facility)
                .Include(c => c.Phone)
                .SingleOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,ClientNum,ClientName,CompanyTypeId,FacilityId,AddressId,ContactId,PhoneId,CountyId,Notes,IsActiveFlg,IsOfficeAccessFlg,CreatedDt,CreatedBy,ModifiedDt,ModifiedBy")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressLine1", client.AddressId);
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyType, "CompanyTypeId", "CompanyTypeName", client.CompanyTypeId);
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "ContactName", client.ContactId);
            ViewData["CountyId"] = new SelectList(_context.County, "CountyId", "CountyName", client.CountyId);
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName", client.FacilityId);
            ViewData["PhoneId"] = new SelectList(_context.Phone, "PhoneId", "PhoneNum", client.PhoneId);
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Include(c => c.Address)
                .Include(c => c.CompanyType)
                .Include(c => c.Contact)
                .Include(c => c.County)
                .Include(c => c.Facility)
                .Include(c => c.Phone)
                .SingleOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.SingleOrDefaultAsync(m => m.ClientId == id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.ClientId == id);
        }
    }
}
