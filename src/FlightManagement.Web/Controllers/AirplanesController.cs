using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightManagement.Core.Domain.Entities;
using FlightManagement.Core.Domain.Repositories;
using FlightManagement.Web.Data;
using FlightManagement.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FlightManagement.Web.Controllers
{
    [Route("[controller]/[action]")]
    //[Authorize]
    public class AirplanesController : Controller
    {
        private readonly IAirplaneRepository _airplaneRepository;

        public AirplanesController(IAirplaneRepository airplaneRepository)
        {
            _airplaneRepository = airplaneRepository;
        }
        // GET: Airplanes
        public async Task<IActionResult> Index()
        {
            var airplanes = await _airplaneRepository.GetAll();

            return View(airplanes.Select(x =>new CreateAirplaneViewModel(x.Id,x.Name,x.SerialNumber,x.Model,x.CreatedBy,x.CreatedDate)));
        }

        // GET: Airplanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,SerialNumber,Model")]CreateAirplaneViewModel airplane)
        {
            if (ModelState.IsValid)
            {
                var newAirplane = Airplane.Create(Guid.NewGuid(), airplane.Name, airplane.SerialNumber, airplane.Model,
                    User.Identity.Name);
                 _airplaneRepository.Add(newAirplane);
                return RedirectToAction(nameof(Index));
            }
            return View(airplane);
        }

        // GET: Airplanes/Edit/5
        public IActionResult Edit(Guid id)
        {
            try
            {
                var airplane = _airplaneRepository.GetById(id);
                var returnAirplane = new CreateAirplaneViewModel(airplane.Id, airplane.Name, airplane.SerialNumber,airplane.Model,
                    airplane.CreatedBy, airplane.CreatedDate);
                return View(returnAirplane);
            }
            catch
            {
                return NotFound();
            }
        }

        //// POST: Airplanes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,SerialNumber,Model")] CreateAirplaneViewModel airplane)
        {
            try
            {
                var selectedAirplane = _airplaneRepository.GetById(id);
                if (ModelState.IsValid)
                {
                    selectedAirplane.Update(airplane.Name, airplane.SerialNumber, airplane.Model);
                    return RedirectToAction(nameof(Index));
                }
                return View(airplane);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
           

            
        }

        //// GET: Airplanes/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var airplane = await _context.Airplanes
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (airplane == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(airplane);
        //}

        //// POST: Airplanes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var airplane = await _context.Airplanes.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Airplanes.Remove(airplane);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AirplaneExists(Guid id)
        //{
        //    return _context.Airplanes.Any(e => e.Id == id);
        //}
    }
}
