using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.DTOs;
using SS.Generic.Interfaces;

namespace SS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _Icustomer;
        public CustomerController(ICustomer customer)
        {
            _Icustomer = customer;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customer = await _Icustomer.Customers();

            var data = customer.Select(x=>new CustomerReadDto
            {
                 Id = x.Id,
                 Name = x.Name,
                 Email = x.Email,
                 Phone = x.Phone,
                 Total = x.artPieces.Sum(p=>p.Price),
                 LoyaltyCard = new LoyaltyCardDtoReadForCustomer
                 {
                      Id = x.LoyaltyCard.Id,
                      CardNumber = x.LoyaltyCard.CardNumber,
                      Blalnce = x.LoyaltyCard.Blalnce
                 },
                 artPieces = x.artPieces.Select(o=>new ArtPieceDtoReadForCustomer
                 {
                     Id= o.Id,
                     Title = o.Title,
                     Description = o.Description,
                     Price = o.Price,
                     CustomerID = o.CustomerID,

                 }).ToList()

            }).ToList();
            return Ok(data);
        }

    }
}
