#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheEviction.Entities.Models;
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

        // GET: Client Data TEST
        public IActionResult Client()
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
        public async Task<IActionResult> Index()
        {
            var evictionDevContext = _context.Client.Include(c => c.Address).Include(c => c.CompanyType).Include(c => c.Contact).Include(c => c.County).Include(c => c.Facility).Include(c => c.Phone);
            return View(await evictionDevContext.ToListAsync());
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

        // GET: Client/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressLine1");
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyType, "CompanyTypeId", "CompanyTypeName");
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "ContactName");
            ViewData["CountyId"] = new SelectList(_context.County, "CountyId", "CountyName");
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName");
            ViewData["PhoneId"] = new SelectList(_context.Phone, "PhoneId", "PhoneNum");
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ClientNum,ClientName,CompanyTypeId,FacilityId,AddressId,ContactId,PhoneId,CountyId,Notes,IsActiveFlg,IsOfficeAccessFlg,CreatedDt,CreatedBy,ModifiedDt,ModifiedBy")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
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
