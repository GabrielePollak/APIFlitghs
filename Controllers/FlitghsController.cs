using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using POntheFly.Models;
using POntheFly.Services;
using System;
using System.Collections.Generic;

namespace POntheFly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlitghsController : ControllerBase
    {
        private readonly FlitghsServices _flitghs;

        public FlitghsController(FlitghsServices flitghs)
        {
            _flitghs = flitghs;
        }

        [HttpGet]
        public ActionResult<List<Flitghs>> GetAllFlitghs() => _flitghs.GetAllFlitghs();

        [HttpGet("GetOne/{fullDate},{rabPlane},{destiny}", Name = "GetOneFligths")]
        public ActionResult<Flitghs> GetOneFlitghs(DateTime fullDate, string rabPlane, string destiny)
        {
            var flitghs = _flitghs.GetOneFlitghs(fullDate, rabPlane, destiny);
            if (flitghs == null)
                return NotFound("Something went wrong in the request, flitghs not found!");

            return Ok(flitghs);

        }


        [HttpPost]
        public ActionResult<Flitghs> CreateFlitghs(Flitghs flitghs)
        {
            _flitghs.CreateFlitghs(flitghs);
            
            return Ok(CreatedAtRoute("GetOneFlitghs", new { destiny = flitghs.Destiny.ToString() }, flitghs));


        }

        [HttpDelete]
        public ActionResult<Flitghs> DeleteFlitghs(DateTime fullDate, string rabPlane, string destiny)
        {
            //procurar se existe 
            Flitghs flitghs = _flitghs.GetOneFlitghs(fullDate, rabPlane, destiny);
            if (flitghs == null) return NotFound("Something went wrong in the request, flitghs not found!");

            _flitghs.RemoveFlitghs(flitghs);
            return NoContent();
        }



    }
}
