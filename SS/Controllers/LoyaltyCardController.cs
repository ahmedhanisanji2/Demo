using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.DTOs;
using SS.Generic.Interfaces;

namespace SS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyCardController : ControllerBase
    {
        private readonly ILoyaltyCard _ILoyalty;

        public LoyaltyCardController(ILoyaltyCard loyaltyCard)
        {
            _ILoyalty = loyaltyCard;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var get = await _ILoyalty.GetLoyalty();

            var loyalty = get.Select(x=>new ReadLoyaDto
            {
                 Id = x.Id,
                 CardNumber = x.CardNumber,
                 Blalnce = x.Blalnce,
                 CustomerId = x.CustomerId,

                  Customer = new ReadLoyaDtoCus
                  {
                       Id = x.Customer.Id,
                       Name = x.Customer.Name,
                       Email = x.Customer.Email,
                       Phone = x.Customer.Phone,
                  }

            }).ToList();

            return Ok(loyalty);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLoya(UpdateLayDto LayDto,int id)
        {
            
            var lay = await _ILoyalty.GetById(id);

            if(lay == null)
            {
                return BadRequest("Id Not Found");
            }

            lay.CardNumber = LayDto.CardNumber;
            lay.Blalnce = LayDto.Blalnce;

            _ILoyalty.UpdateAsync(lay);
            await _ILoyalty.SaveChangesAsync();

            return Ok(LayDto);
        }


    }
}
