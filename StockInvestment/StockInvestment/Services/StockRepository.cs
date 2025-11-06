using StockInvestment.Models;

namespace StockInvestment.Services
{
    public class StockServices: IRepositoryStock
    {
        private readonly StockInvestmentContext _context;
        public StockServices(StockInvestmentContext context)
        {
            _context = context;
        }
        public IEnumerable<Stock> GetAllStocks() =>
            _context.Stocks.ToList();
        public Stock GetStockById(int id) =>
            _context.Stocks.FirstOrDefault(s => s.StockId == id);
        public void CreateStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            _context.SaveChanges();
        }

        public void UpdateStock(Stock stock)
        {
            _context.Stocks.Update(stock);  // Mark the student as modified
            _context.SaveChanges();  // Commit the changes to the database
        }

        public void DeleteStock(int id)
        {
            var stock = GetStockById(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                _context.SaveChanges();
            }
        }

    }
}
