using Microsoft.AspNetCore.Http;    
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaDeFrutas.Contracts;
using TiendaDeFrutas.Data;
using TiendaDeFrutas.Dto;
using TiendaDeFrutas.Entities;
using TiendaDeFrutas.Services.Contracts;
using TiendaDeFrutas.Services.Contracts.impl;

namespace TiendaDeFrutas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketPlaceController : ControllerBase
    {
        private readonly IFruitService _fruitService;

        public MarketPlaceController(IFruitService fruitService) => _fruitService = fruitService;

        [HttpGet("getAllFruits")]
        public async Task<ActionResult<List<Fruit>>> GetAllFruits()
        {
            var fruits = await _fruitService.GetAllFruits();

            if (fruits is null)
            {
                return NotFound("fruits not found");
            }

            return Ok(fruits);
        }


        [HttpGet("getFruit/{id}")]
        public async Task<ActionResult<Fruit>> GetFruit(int id)
        {
            var fruit = await _fruitService.GetFruit(id);
            if (fruit is null)
            {
                return NotFound("fruit not found.");
            }
            return Ok(fruit);
        }


        [HttpPost("createFruit")]
        public async Task<ActionResult<Fruit>> AddFruit(Fruit fruit)
        {
            if (fruit is null)
            {
                return NotFound("Validate information, it can't be null");
            }

            return Ok(await _fruitService.AddFruit(fruit));
        }


        [HttpPut]
        public async Task<ActionResult<List<Fruit>>> UpdateFruit(UpdateFruitDto updateFruit)
        {
            var update = await _fruitService.GetFruit(updateFruit.Id);
            if (update is null)
            {
                return NotFound("fruit not found.");
            }

            return Ok(await _fruitService.UpdateFruit(updateFruit));
        }


            [HttpDelete("deleteFruit")]
        public async Task<ActionResult<string>> DeleteFruit(int id)
        {
            var delete = await _fruitService.DeleteFruit(id);
                if (delete is null)
            {
                return NotFound("fruit not found.");
            }

            return Ok(delete);
        }
    }


}
