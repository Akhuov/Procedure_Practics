using Dapper;
using Domain_;
using System.Data;
using System.Data.SqlClient;
using WEP_API_003.Interfaces;

namespace WEP_API_003.Services
{
    public class StudentsRepository : IStudentsRepository
    {
        private string connectionString = "Server = WIN-F7NIMF7A3VO;Database = BootCamp_N7;Trusted_Connection = True;Pooling = True;";
        public async Task<Student> GetStudentById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("id", id);

                var student = await connection.QueryFirstOrDefaultAsync<Student>("ExProcedure", parameters, commandType: CommandType.StoredProcedure);
                return student;
            }
        }


        public async Task<IEnumerable<Student>> GetStudentsByYear(int start, int end)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("beginDate", start);
                parameters.Add("endDate", end);

                var student = await connection.QueryAsync<Student>("ExProcedure_2", parameters, commandType: CommandType.StoredProcedure);
                return student;
            }
        }
    }
}
