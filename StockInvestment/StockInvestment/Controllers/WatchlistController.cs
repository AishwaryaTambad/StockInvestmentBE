using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockInvestment.Models;
using StockInvestment.Services;

namespace StockInvestment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly IRepositoryWatchlist _repository;
        public WatchlistController(IRepositoryWatchlist repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllWatchlists()
        {
            var watchLists = _repository.GetAllWatchlist();
            return Ok(watchLists);
        }

        [HttpGet("stock/{stockId}")]
        public IActionResult GetWatchlistByStockId(int stockId)
        {
            var watchLists = _repository.GetWatchlistByStockId(stockId);
            if (watchLists == null)
                return NotFound();

            return Ok(watchLists);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetWatchlistByUserId(int userId)
        {
            var watchLists = _repository.GetWatchlistByUserId(userId);
            if (watchLists == null)
                return NotFound();

            return Ok(watchLists);
        }

        [HttpGet("{id}")]
        public IActionResult GetWatchListById(int id)
        {
            var watchList = _repository.GetWatchlistById(id);
            if (watchList == null)
                return NotFound();

            return Ok(watchList);
        }

        [HttpPost]
        public IActionResult AddStockIntoWatchList([FromBody] Watchlist stock)
        {
            if (stock == null)
                return BadRequest();

            _repository.AddStockIntoWatchlist(stock);
            return CreatedAtAction(nameof(GetWatchListById), new { id = stock.WatchlistId }, stock);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStockFromWatchlist(int id)
        {
            //if (id != user.UserId)
            //    return BadRequest("User ID mismatch");

            var existingStock = _repository.GetWatchlistById(id);

            if (existingStock == null)
                return NotFound("Stock not found");

            _repository.RemoveStockFromWatchlist(id);

            return Ok("Stock removed from watchlist");
        }
    }
}
