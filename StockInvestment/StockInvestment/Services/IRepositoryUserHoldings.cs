using StockInvestment.Models;

namespace StockInvestment.Services
{
    public interface IRepositoryUserHoldings
    {
        IEnumerable<UserHolding> GetAllUserHoldings();
        UserHolding GetUserHoldingByUserId(int userId);
        UserHolding GetUserHoldingByStockId(int stockId);

        UserHolding GetUserHoldingById(int id);
        void UpdateUserHolding(UserHolding userHolding);
    }
}
