using StockInvestment.Models;

namespace StockInvestment.Services
{
    public class UsersServices : IRepositoryUsers
    {
        private readonly StockInvestmentContext _context;
        public UsersServices(StockInvestmentContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers() =>
            _context.Users.ToList();  
        public User GetUserById(int id) =>
            _context.Users.FirstOrDefault(s => s.UserId == id);

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user) {
            _context.Users.Update(user);  // Mark the student as modified
            _context.SaveChanges();  // Commit the changes to the database
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}
