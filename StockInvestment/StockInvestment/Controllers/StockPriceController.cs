using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockInvestment.Models;
using StockInvestment.Services;

namespace StockInvestment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPriceController : ControllerBase
    {

        private readonly IRepositoryStockPrice _repository;

        public StockPriceController(IRepositoryStockPrice repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAllStockPrice()
        {
            var stockPrices = _repository.GetAllStockPrices();
            return Ok(stockPrices);
        }

        [HttpGet("stock/{stockId}")]
        public IActionResult GetStockPriceByStockId(int stockId)
        {
            var stockPrice = _repository.GetStockPriceByStockId(stockId);
            if (stockPrice == null)
                return NotFound();

            return Ok(stockPrice);
        }


        [HttpGet("price/{priceId}")]
        public IActionResult GetStockPriceById(int priceId)
        {
            var stockPrice = _repository.GetStockPriceById(priceId);
            if (stockPrice == null)
                return NotFound();

            return Ok(stockPrice);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStockPrice(int id, [FromBody] StockPrice stockPrice)
        {
            Console.WriteLine(id);
            if (id != stockPrice.PriceId)
                return BadRequest("Price  ID mismatch");

            var existingStockPrice = _repository.GetStockPriceById(id);

            if (existingStockPrice == null)
                return NotFound("Stock not found");


            existingStockPrice.Price = stockPrice.Price;
            existingStockPrice.PriceDate = DateTime.Now;

            _repository.UpdateStockPrice(existingStockPrice);

            return Ok(existingStockPrice);
        }
    }
}
