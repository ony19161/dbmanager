using Demo.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Sql.API.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentQueryService _studentQueryService;

        public StudentController(IStudentQueryService studentQueryService)
        {
            _studentQueryService = studentQueryService;
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public async Task<IActionResult> GetStudentInfo(int id)
        {
            try
            {
                var studentInfo = await _studentQueryService.GetStudentInfoAsync(id);

                return Ok(studentInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
