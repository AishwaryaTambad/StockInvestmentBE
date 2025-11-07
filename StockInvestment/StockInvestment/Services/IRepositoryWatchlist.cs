using StockInvestment.Models;

namespace StockInvestment.Services
{
    public interface IRepositoryWatchlist
    {
        IEnumerable<Watchlist> GetAllWatchlist();
        Watchlist GetWatchlistByUserId(int userId);
        Watchlist GetWatchlistByStockId(int stockId);
        Watchlist GetWatchlistById(int id);
        void AddStockIntoWatchlist(Watchlist stock);
        void RemoveStockFromWatchlist(int id);
    }
}
