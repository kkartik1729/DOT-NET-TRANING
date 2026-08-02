using _30Jul2026.Models;

namespace _30Jul2026.Services
{
    
        public interface IStudentService
        {
            List<Student> GetStudents();

            Student? GetStudentByID(int id);

            void AddStudent(Student student);
        }
    }

