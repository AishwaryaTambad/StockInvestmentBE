using StockInvestment.Models;

namespace StockInvestment.Services
{
    public class UserHoldingServices: IRepositoryUserHoldings
    {
        private readonly StockInvestmentContext _context;
        public UserHoldingServices(StockInvestmentContext context)
        {
            _context = context;
        }
        public IEnumerable<UserHolding> GetAllUserHoldings() =>
           _context.UserHoldings.ToList();
        public UserHolding GetUserHoldingByUserId(int userId) =>
            _context.UserHoldings.FirstOrDefault(s => s.UserId == userId);
        public UserHolding GetUserHoldingByStockId(int stockId) =>
            _context.UserHoldings.FirstOrDefault(s => s.UserId == stockId);

        public UserHolding GetUserHoldingById(int id) =>
           _context.UserHoldings.FirstOrDefault(s => s.HoldingId == id);

        public void UpdateUserHolding(UserHolding userHolding)
        {
            _context.UserHoldings.Update(userHolding);
            _context.SaveChanges();
        }
    }
}
