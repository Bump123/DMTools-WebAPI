using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DMApi.Services;
using DMApi.Models;
using DMApi.Repositories;

namespace DMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly ILogger<UnitsController> _logger;
        private readonly IUnitRepsitory _unitRepository;


        public UnitsController(ILogger<UnitsController> logger, IUnitRepsitory unitRepsitory)
        {
            _logger = logger;
            _unitRepository = unitRepsitory;
        }

        [HttpGet("/unit/{id}")]
        public IActionResult Get(int id)
        {
            var unit = _unitRepository.GetUnit(id);
            if (unit == null)
            {
                return NotFound();
            }
            return Ok(unit);
        }

        [HttpGet]
        public IActionResult GetAllUnits()
        {
            var unit = _unitRepository.GetAll();
            if (unit == null)
            {
                return NotFound();
            }
            return Ok(unit);
        }

        [HttpPost]
        public ActionResult CreateUnit(Unit unit) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitRepository.AddUnit(unit);
            return CreatedAtAction(nameof(Get), new { id = unit.Id }, unit);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUnit(int id)
        {
            Unit unit = _unitRepository.GetUnit(id);
            
            if (unit == null) { return NotFound(); }

            _unitRepository.RemoveUnit(unit);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUnit(Unit unit, int id)
        {
            unit = _unitRepository.GetUnit(id);
            if (unit == null) { return BadRequest(ModelState); }
            _unitRepository.UpdateUnit(unit);
            return Ok();
        }
    }
}
