using Demo.Dto.Request;
using Demo.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MySql.API.Controllers
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

        [HttpGet]
        [Route("api/student/list")]
        public async Task<IActionResult> GetStudentList([FromQuery] StudentFilterRequest filterRequest)
        {
            try
            {
                var studentList = await _studentQueryService.GetStudentsByFilter(filterRequest);

                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
