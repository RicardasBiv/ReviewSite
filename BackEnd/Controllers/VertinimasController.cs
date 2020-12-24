using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class VertinimasController : ControllerBase
    {
        private readonly IVertinimasService _vertinimasService;
        private readonly IKomentarasService _komentarasService;
        public VertinimasController(IVertinimasService vertinimasService,IKomentarasService komentarasService)
        {
            _vertinimasService = vertinimasService;
            _komentarasService = komentarasService;
        }
        // GET: api/vertinimas
        //[Authorize(Roles = "Admin,User,Writer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGrade()
        {
            var vertinimas = await _vertinimasService.GetAllVertinimas();
            return Ok(vertinimas);
        }
        // GET: api/vertinimas/5
        //[Authorize(Roles = "Admin,Writer")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGrade(int id)
        {
            var vertinimas = await _vertinimasService.GetVertinimas(id);

            if (vertinimas == null)
            {
                return NotFound($"Grade with id = {id} not found");
            }
            return Ok(vertinimas);
        }
        // Post api/review
        //[Authorize(Roles = "Admin,Writer,User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddComment([FromBody] VertinimasRequest vertinimasRequest)
        {
            var vertinimas = await _vertinimasService.AddVertinimas(vertinimasRequest);
            if (vertinimas == null)
            {
                return BadRequest("Incorrect vertinimas data");
            }
            return CreatedAtAction(nameof(GetGrade), new { id = vertinimas.Id }, vertinimas);
        }
        // Put api/review/id
       // [Authorize(Roles = "Admin,Writer,User")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] VertinimasRequest vertinimasRequest)
        {
            var vertinimas = await _vertinimasService.GetVertinimas(id);
            if (vertinimas == null)
            {
                return NotFound($"Grade with id = {id} not found");
            }
            var vertinimasUpdated = await _vertinimasService.UpdateVertinimas(id, vertinimasRequest);
            if (vertinimasUpdated == null)
            {
                return BadRequest();
            }
            return Ok(vertinimasUpdated);
        }
        //[Authorize(Roles = "Admin,Writer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGrade([FromRoute] int id)
        {
            var vertinimas = await _vertinimasService.Get(id);
            if (vertinimas == null)
            {
                return NotFound($"Grade with id = {id} not found");
            }
            var vertinimasDeleted = await _vertinimasService.DeleteVertinimas(id);

            return Ok(vertinimasDeleted);
        }
    }
}
