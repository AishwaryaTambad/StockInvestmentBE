using StockInvestment.Models;

namespace StockInvestment.Services
{
    public interface RepositoryStudent
    {
        IEnumerable<Student1> GetAllStudents();
        Student1 GetStudentById(int id);
        void CreateStudent(Student1 student);
        void UpdateStudent(Student1 student);
        void DeleteStudent(int id);

    }
}
