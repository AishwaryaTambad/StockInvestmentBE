using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockInvestment.Models;
using StockInvestment.Services;

namespace StockInvestment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHoldingController : ControllerBase
    {
        private readonly IRepositoryUserHoldings _repository;
        public UserHoldingController(IRepositoryUserHoldings repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllUserHoldings() {
            var userHoldings = _repository.GetAllUserHoldings();
            return Ok(userHoldings);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserHoldingByUserId(int userId)
        {
            var userHolding = _repository.GetUserHoldingByUserId(userId);
            if (userHolding == null)
                return NotFound();

            return Ok(userHolding);
        }

        [HttpGet("stock/{stockId}")]
        public IActionResult GetUserHoldingByStockId(int stockId)
        {
            var userHolding = _repository.GetUserHoldingByStockId(stockId);
            if (userHolding == null)
                return NotFound();

            return Ok(userHolding);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserHoldingById(int id)
        {
            var userHolding = _repository.GetUserHoldingById(id);
            if (userHolding == null)
                return NotFound();

            return Ok(userHolding);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUserHolding(int id, [FromBody] UserHolding userHolding)
        {
            Console.WriteLine(id);
            if (id != userHolding.HoldingId)
                return BadRequest("User holding ID mismatch");

            var existingUserHolding = _repository.GetUserHoldingById(id);

            if (existingUserHolding == null)
                return NotFound("Stock not found");


            existingUserHolding.Quantity = userHolding.Quantity;
            existingUserHolding.PurchasePrice = userHolding.PurchasePrice;
            existingUserHolding.PurchaseDate = DateOnly.FromDateTime(DateTime.Now);

            _repository.UpdateUserHolding(existingUserHolding);

            return Ok(existingUserHolding);
        }
    }
}
