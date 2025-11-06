using StockInvestment.Models;

namespace StockInvestment.Services
{
    public interface IRepositoryUsers
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

    }
}
