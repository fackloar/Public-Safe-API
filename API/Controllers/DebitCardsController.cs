#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Safe_Development.API.Responses;
using Safe_Development.BusinessLayer.DTOs;
using Safe_Development.BusinessLayer.Interfaces;
using Safe_Development.DataLayer.Models;

namespace Safe_Development.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitCardsController : ControllerBase
    {
        private IDebitCardService _debitCardService;

        public DebitCardsController(IDebitCardService debitCardService)
        {
            _debitCardService = debitCardService;
        }

        // GET: api/DebitCards
        [HttpGet]
        public async Task<ActionResult<GetDebitCardsResponse>> GetDebitCards()
        {
            var response = new GetDebitCardsResponse()
            {
                debitCards = new List<DebitCardDTO>()
            };
            var debitCards = await _debitCardService.GetCards();
            foreach (var debitCard in debitCards)
            {
                response.debitCards.Add(debitCard);
            }
            return response;
        }

        // GET: api/DebitCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDebitCardByIdResponse>> GetDebitCard(int id)
        {
            var response = await _debitCardService.GetDebitCardById(id);
            if (response.Succeed)
            {
                return Ok(response.Result);
            }
            else
            {
                return UnprocessableEntity(response.Failures);
            }
        }

        // PUT: api/DebitCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDebitCard(int id, string name)
        {
            await _debitCardService.Update(id, name);
            return Ok();
        }

        // POST: api/DebitCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DebitCard>> PostDebitCard(DebitCardDTO debitCard)
        {
            var response = await _debitCardService.CreateDebitCard(debitCard);
            if (response.Succeed)
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity(response.Failures);
            }
        }

        // DELETE: api/DebitCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDebitCard(int id)
        {
            await _debitCardService.Delete(id);
            return Ok();
        }
    }
}
