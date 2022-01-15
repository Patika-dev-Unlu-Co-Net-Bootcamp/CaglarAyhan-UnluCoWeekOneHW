using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using UnluCoWeekOneHW.Entities;
using UnluCoWeekOneHW.Error_Management;
using UnluCoWeekOneHW.Repositories;

namespace UnluCoWeekOneHW.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ScientistsController : ControllerBase
    {
        ScientistRepository _scientistRepository;
        public List<Scientist> scientistsDb = new List<Scientist>()
        {
            new Scientist
            {
                ScientistId=1,
                ScientistName="Albert",
                ScientistSecondName="Einstein",
                ScientistFieldOfStudy="theoretical physics",
                ScientistNationality="Germany",
                Popularity=1200,
                ScientistUniversity="University Of Zurich"
            },
                  new Scientist
            {
                ScientistId=2,
                ScientistName="Max",
                ScientistSecondName="Planck",
                ScientistFieldOfStudy="theoretical physics",
                ScientistNationality="Germany",
                Popularity=1000,
                ScientistUniversity="Ludwig Maximilian University of Munich",
                isActive=true
            },
                        new Scientist
            {
                ScientistId=3,
                ScientistName="Marie Salomea Skłodowska",
                ScientistSecondName="Curie ",
                ScientistFieldOfStudy="physicist and chemist ",
                ScientistNationality="Germany",
                Popularity=1100,
                ScientistUniversity="University of Paris",
                isActive=true
            }
        };

        [HttpGet("scientists")]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<IEnumerable<Scientist>> GetAll()
        {
            
            var scientistList = scientistsDb.OrderBy(a => a.ScientistName).ToList();
            if (scientistList.Count > 0)
            {
                return Ok(scientistList);
            }
            else
                return BadRequest(Messages.EmptyResults);           
        }
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Scientist>> GetById(int id)
        {
            var scientistList = scientistsDb.Where(a => a.ScientistId == id).ToList();
            if (scientistList.Count != 0)
            {
                return Ok(scientistList);
            }
            else
                return NotFound(Messages.WrongRequest);           
        }
        [HttpPost("SuggestNewScientist")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.Created)]
        public IActionResult SuggestScientist([FromForm] Scientist newscientist)
        {
            var scientist = scientistsDb.SingleOrDefault(a=>a.ScientistId == newscientist.ScientistId);
            if(scientist != null)
            {
                return BadRequest();
            }
            scientistsDb.Add(newscientist);          
            return StatusCode(201);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteScientistById (int id)
        {
            var scientist = scientistsDb.Where(a => a.ScientistId == id).SingleOrDefault();

            scientistsDb.Remove(scientist);

            return Ok($"{id}'id numarasına sahip veri silinmiştir.");
        }
        [HttpPatch("{id}/update")]
        public IActionResult UpdateScientistName(int id, [FromBody] Scientist updatedscientistName)
        {
            var sci = scientistsDb.SingleOrDefault(x=>x.ScientistId==id);
            if(sci==null)
            {
                return StatusCode(204);
            }
            sci.ScientistName = updatedscientistName.ScientistName;
            return Ok();
        }
        
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotModified)]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        public IActionResult Update (int id ,[FromBody] Scientist scientist)
        {
            var data = scientistsDb.Where(a => a.ScientistId == scientist.ScientistId).FirstOrDefault();
            if(data != null)
            {
                data.ScientistName = scientist.ScientistName;
                data.ScientistSecondName = scientist.ScientistSecondName;

                return Ok(data);
            }
            return BadRequest();
           
        }
    }
}
