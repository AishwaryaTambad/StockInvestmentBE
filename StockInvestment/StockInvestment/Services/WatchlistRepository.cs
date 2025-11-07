using StockInvestment.Models;

namespace StockInvestment.Services
{
    public class WatchlistServices:IRepositoryWatchlist
    {

        private readonly StockInvestmentContext _context;
        public WatchlistServices(StockInvestmentContext context)
        {
            _context = context;
        }

        public IEnumerable<Watchlist> GetAllWatchlist() =>
           _context.Watchlists.ToList();
        public Watchlist GetWatchlistByStockId(int stockId) =>
            _context.Watchlists.FirstOrDefault(s => s.StockId == stockId);
        public Watchlist GetWatchlistByUserId(int userId) =>
           _context.Watchlists.FirstOrDefault(s => s.UserId == userId);
        public Watchlist GetWatchlistById(int id) =>
            _context.Watchlists.FirstOrDefault(s => s.WatchlistId == id);
        public void AddStockIntoWatchlist(Watchlist watchlist)
        {
            _context.Watchlists.Add(watchlist);
            _context.SaveChanges();
        }

        public void RemoveStockFromWatchlist(int id)
        {
            var watchlist = GetWatchlistById(id);
            if (watchlist != null)
            {
                _context.Watchlists.Remove(watchlist);
                _context.SaveChanges();
            }
        }
    }
}
