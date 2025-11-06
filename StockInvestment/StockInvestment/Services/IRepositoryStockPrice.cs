using StockInvestment.Models;

namespace StockInvestment.Services
{
    public interface IRepositoryStockPrice
    {

        IEnumerable<StockPrice> GetAllStockPrices();
        StockPrice GetStockPriceByStockId(int stockId);
        StockPrice GetStockPriceById(int id);
        void UpdateStockPrice(StockPrice stock);
        //void DeleteUser(int id);
    }
}
