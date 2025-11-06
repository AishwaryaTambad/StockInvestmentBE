using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockInvestment.Models;
using StockInvestment.Services;

namespace StockInvestment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IRepositoryStock _repository;

        public StockController(IRepositoryStock repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllStocks()
        {
            var stocks = _repository.GetAllStocks();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetStockById(int id)
        {
            var stock = _repository.GetStockById(id);
            if (stock == null)
                return NotFound();

            return Ok(stock);
        }

        [HttpPost]
        public IActionResult CreateStock([FromBody] Stock stock)
        {
            if (stock == null)
                return BadRequest();

            _repository.CreateStock(stock);
            return CreatedAtAction(nameof(GetStockById), new { id = stock.StockId }, stock);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStock(int id, [FromBody] Stock stock)
        {
            if (id != stock.StockId)
                return BadRequest("Stock ID mismatch");

            var existingStock = _repository.GetStockById(id);

            if (existingStock == null)
                return NotFound("Stock not found");


            existingStock.CompanyName = stock.CompanyName;
            existingStock.Sector = stock.Sector;
            existingStock.TickerSymbol = stock.TickerSymbol;


            _repository.UpdateStock(existingStock);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStock(int id)
        {
            //if (id != user.UserId)
            //    return BadRequest("User ID mismatch");

            var existingStock = _repository.GetStockById(id);

            if (existingStock == null)
                return NotFound("Stock not found");

            _repository.DeleteStock(id);

            return Ok("Stock deleted successfully");
        }

    }
}
