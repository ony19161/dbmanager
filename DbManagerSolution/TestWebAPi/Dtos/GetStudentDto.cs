namespace TestWebAPi.Dtos
{
    public class GetStudentDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public float Cgpa { get; set; }
    }
}
