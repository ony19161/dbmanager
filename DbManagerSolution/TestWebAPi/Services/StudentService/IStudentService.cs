using TestWebAPi.Dtos;
using TestWebAPi.Models;

namespace TestWebAPi.Services.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents();

        //Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);

        //Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);

        //Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);

        //Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
        //Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
    }
}
