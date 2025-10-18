using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.DTOs;
using SS.Generic.Interfaces;
using SS.Models;

namespace SS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtPieceController : ControllerBase
    {
        private readonly IArtPiece _IArtpiece;
        private readonly ICategory _Icategory;
        private readonly ICustomer _iCustomer;
        public ArtPieceController(IArtPiece artPiece, ICategory icategory,ICustomer customer)
        {
            _IArtpiece = artPiece;
            _Icategory = icategory;
            _iCustomer = customer;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtPiece(ArtPieceDtoCreate ArtPieceDto)
        {
            var Art = new ArtPiece
            {
                  Title = ArtPieceDto.Title,
                  Price = ArtPieceDto.Price,
                  Description = ArtPieceDto.Description,
                  CustomerID = ArtPieceDto.CustomerID,
            };
            


            foreach(var C in ArtPieceDto.categories)
            {
                var cat = await _Icategory.GetById(C);
                if(cat == null)
                {
                    return BadRequest("Category Not found");
                }

                if (cat != null)
                {
                    Art.categories.Add(cat);
                    await _Icategory.SaveChangesAsync();
                }

            }

            await _IArtpiece.AddAsync(Art);
            await _IArtpiece.SaveChangesAsync();

            return Ok(ArtPieceDto);

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var get =await _IArtpiece.GetAlls();

            var art = get.Select(x => new DtoReadArt
            {
                 Id = x.Id,
                 Price = x.Price,
                 Description = x.Description,
                  Title = x.Title,
                 CustomerID= x.CustomerID,
                  Customer = new CustomerReadDtoForArt
                  {
                       Id= x.Customer.Id,
                       Email = x.Customer.Email,
                       Name = x.Customer.Name,
                       Phone = x.Customer.Phone,
                  },
                   categories = x.categories.Select(o=>new CategoryReadDtoForArt
                   {
                        Id = o.Id,
                        Name = o.Name,

                   }).ToList()
                  
            }).ToList();

            return Ok(art);
        }
        [HttpGet("Category")]
        public async Task<IActionResult> GetAll()
        {
            var get = await _Icategory.categories();

            var all = get.Select(x => new CategoriesDtoForArt
            {
                  Id = x.Id,
                  Name = x.Name,
                  NumOfPiece = x.artPieces.Count(),
                  AveragePrice = x.artPieces.Average(x=>x.Price),
                  artPieces = x.artPieces.Select(o=>new ArtDto
                  {
                       Id = o.Id,
                       Title = o.Title,
                       Description = o.Description,
                       Price= o.Price,
                       CustomerID = o.CustomerID

                  }).ToList()
                  
                   
            }).ToList();

            return Ok(all);

        }
        [HttpGet("Customer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var get = await _iCustomer.CustomersUnique();

            var customer = get.Select(x=>new CustDto
            {
                 Id= x.Id,
                 Name = x.Name,
                 Email = x.Email,
                 Phone = x.Phone,

            }).ToList();

            return Ok(customer);

        }
        [HttpGet("spending/summary")]
        public async Task<IActionResult> GetSpendingSummary()
        {
            var get = await _Icategory.SummaryCat();

            var cat = get.Select(x => new DtoCatAuthArt
            {
                Id = x.Id,
                Name = x.Name,
                TotalRevenue = x.artPieces.Sum(x => x.Price),
                artPieces = x.artPieces != null ? x.artPieces.Select(o => new DtoAART
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    Price = o.Price,
                    CustomerID = o.CustomerID,
                    Customer = o.Customer != null ? new DtoCUSTT
                    {
                        Id = o.Customer.Id,
                        Name = o.Customer.Name,
                        Email = o.Customer.Email,
                        Phone = o.Customer.Phone,
                        LoyaltyCard = o.Customer.LoyaltyCard != null? new DtoLay
                        {
                            Id = o.Customer.LoyaltyCard.Id,
                            CardNumber = o.Customer.LoyaltyCard.CardNumber,
                            Blalnce = o.Customer.LoyaltyCard.Blalnce,
                            CustomerId = o.Customer.LoyaltyCard.CustomerId

                        } : null,

                    }: null,

                }).ToList(): null,

            }).GroupBy(x => x.Name).Select(g => new
            {
                Name = g.Key,
                Category = g.ToList(),

            }).ToList();
            return Ok(cat);
        }
    }
}
