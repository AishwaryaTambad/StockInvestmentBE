using StockInvestment.Models;

namespace StockInvestment.Services
{
    public class StockPriceServices: IRepositoryStockPrice
    {
        private readonly StockInvestmentContext _context;
        public StockPriceServices(StockInvestmentContext context)
        {
            _context = context;
        }

        public IEnumerable<StockPrice> GetAllStockPrices() =>
            _context.StockPrices.ToList();
        public StockPrice GetStockPriceByStockId(int stockId) =>
            _context.StockPrices.FirstOrDefault(s => s.StockId == stockId);
        public StockPrice GetStockPriceById(int id) =>
            _context.StockPrices.FirstOrDefault(s => s.PriceId == id);
        public void UpdateStockPrice(StockPrice stockPrice)
        {
            _context.StockPrices.Update(stockPrice);  
            _context.SaveChanges();  
        }

    }
}
