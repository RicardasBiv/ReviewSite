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
        [Route("api/comment")]
        [ApiController]
        public class KomentarasController : ControllerBase
        {
            private readonly IKomentarasService _komentarasService;
            public KomentarasController(IKomentarasService komentarasService)
            {
                _komentarasService = komentarasService;
            }
        // GET: api/comment
        [HttpGet("review/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<IActionResult> GetAllComments(int id)
            {
                var comments = await _komentarasService.GetAllKomentarai(id);
                return Ok(comments);
            }
            // GET: api/comment/5
            //[Authorize(Roles = "Admin,Writer")]
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> GetComment(int id)
            {
                var comment = await _komentarasService.GetKomentaras(id);

                if (comment == null)
                {
                    return NotFound($"Comment with id = {id} not found");
                }
                return Ok(comment);
            }
            // Post api/review
            //[Authorize(Roles = "Admin,Writer,User")]
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> AddComment([FromBody] KomentarasRequest komentarasrequest)
            {
                var komentaras = await _komentarasService.AddKomentaras(komentarasrequest);
                if (komentaras == null)
                {
                    return BadRequest("Incorrect comment data");
                }
                return CreatedAtAction(nameof(GetComment), new { id = komentaras.Id }, komentaras);
            }
            // Put api/review/id
            //[Authorize(Roles = "Admin,Writer,User")]
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] KomentarasRequest komentarasRequest)
            {
                var komentaras = await _komentarasService.GetKomentaras(id);
                if (komentaras == null)
                {
                    return NotFound($"Comment with id = {id} not found");
                }
                var komentarasUpdated = await _komentarasService.UpdateKomentaras(id, komentarasRequest);
                if (komentarasUpdated == null)
                {
                    return BadRequest();
                }
                return Ok(komentarasUpdated);
            }
            //[Authorize(Roles = "Admin,Writer")]
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> DeleteComment([FromRoute] int id)
            {
                var komentaras = await _komentarasService.GetKomentaras(id);
                if (komentaras == null)
                {
                    return NotFound($"comment with id = {id} not found");
                }
                var komentarasDeleted = await _komentarasService.DeleteKomentaras(id);

                return Ok(komentarasDeleted);
            }
        }
}
