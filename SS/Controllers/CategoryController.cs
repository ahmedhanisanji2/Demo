using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.DTOs;
using SS.Generic.Interfaces;

namespace SS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _Icategory;
        public CategoryController(ICategory category)
        {
         _Icategory = category;   
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryies()
        {
            var all = await _Icategory.categories();

            var cat = all.Select(x=>new CategoriesReadDto
            {
                 Id = x.Id,
                 Name = x.Name,
                 Total = x.artPieces.Count(),
                  artPieces = x.artPieces.Select(o=>new ArtPoecesForCategoriesReadDto
                  {
                       Id=o.Id,
                       Title = o.Title,
                       Description = o.Description,
                       Price = o.Price,
                       CustomerID = o.CustomerID,

                  }).ToList(),

            }).ToList();

            return Ok(cat);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteIf(int id)
        {
            var cat = await _Icategory.GetById(id);

            if (cat == null) 
            {
                return BadRequest("Id Not Found");
            }

            var delete = await _Icategory.DeleteIF(id);

            if (delete)
            {
                return BadRequest("There is ArtPiece");
            }
            _Icategory.DeleteAsync(cat);
            await _Icategory.SaveChangesAsync();

            return Ok(new
            {
                cat.Id,
                cat.Name,
            });
        }

    }
}
