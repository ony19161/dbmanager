using Demo.Db.Models;
using Demo.Dto.Request;
using Demo.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Sql.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentQueryService _studentQueryService;

        public StudentController(IStudentQueryService studentQueryService)
        {
            _studentQueryService = studentQueryService;
        }

        [HttpGet]
        [Route("{id}")]
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
        [Route("GetAll")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var studentList = await _studentQueryService.GetAllStudent();

                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var studentList = await _studentQueryService.DeleteStudent(id);

                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("list")]
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

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentDTO addStudentDTO)
        {
            try
            {
                var studentList = await _studentQueryService.AddStudentSevice(addStudentDTO);

                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDTO updateStudentDTO)
        {
            try
            {
                var result = await _studentQueryService.UpdateStudentSevice(updateStudentDTO);

                if (result != -1)
                {
                    return Ok(result);
                }

                return BadRequest("Couldn't update the entity");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
