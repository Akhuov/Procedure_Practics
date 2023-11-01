using Domain_;

namespace WEP_API_003.Interfaces
{
    public interface IStudentsRepository
    {
        public Task<Student> GetStudentById(int id);
        public Task<IEnumerable<Student>> GetStudentsByYear(int start, int end);
    }
}
