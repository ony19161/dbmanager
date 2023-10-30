using AutoMapper;
using DbManager.Implementations;
using DbManager.Interfaces;
using TestWebAPi.Data;
using TestWebAPi.Models;

namespace TestWebAPi.Repositories
{
    public class StudentRepositories : BaseRepository<Student>
    {
        private readonly IMapper mapper;
        private readonly DataContext _context;

        public StudentRepositories(IDbContext dbContext) : base(dbContext)
        {
        }

        //public StudentRepositories(IMapper _mapper,DataContext context)
        //{
        //    mapper = _mapper;
        //    _context = context;
        //}
    }
}
