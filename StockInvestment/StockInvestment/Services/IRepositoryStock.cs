using StockInvestment.Models;

namespace StockInvestment.Services
{
    public interface IRepositoryStock
    {
        IEnumerable<Stock> GetAllStocks();
        Stock GetStockById(int id);
        void CreateStock(Stock stock);
        void UpdateStock(Stock stock);
        void DeleteStock(int id);
    }
}
