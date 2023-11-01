using Microsoft.AspNetCore.Mvc;
using WEP_API_003.Interfaces;

namespace WEP_API_003.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly IStudentsRepository studentsRepository;
        public StudentsController(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }


        [HttpGet("By ID")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await studentsRepository.GetStudentById(id);
            return Ok(result);
        }

        [HttpGet("ByYear")]
        public async Task<IActionResult> GetByIdAsync(int begin, int end)
        {
            var result = await studentsRepository.GetStudentsByYear(begin, end);
            return Ok(result);
        }
    }
}