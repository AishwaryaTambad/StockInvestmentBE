//namespace StockInvestment.Services
//{
//    public class StudentRepository
//    {
//    }
//}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using StockInvestment.Models;
namespace StockInvestment.Services
{
    public class StudentServices: RepositoryStudent
    {
        private readonly StudentDbContext _context;
        public StudentServices(StudentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student1> GetAllStudents() =>
            _context.Student1s.ToList();

        public Student1 GetStudentById(int id) =>
            _context.Student1s.FirstOrDefault(s => s.Id == id);

        public void CreateStudent(Student1 student)
        {
            _context.Student1s.Add(student);
            _context.SaveChanges();
        }


        public void UpdateStudent(Student1 student)
        {
            _context.Student1s.Update(student);  // Mark the student as modified
            _context.SaveChanges();  // Commit the changes to the database
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                _context.Student1s.Remove(student);
                _context.SaveChanges();
            }
        } 
}
}
