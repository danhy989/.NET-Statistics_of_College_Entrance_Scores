using Crawl_College_Entrance_Scores;
using Crawl_College_Entrance_Scores.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Repository
{
    public interface ICollegeRepository
    {
        Task<CollegeEntity> findByCode(string code);
        Task<IEnumerable<CollegeEntity>> GetAll();
    }
    public class CollegeRepository : ICollegeRepository
    {
        private readonly EntranceScoresContext _context;

        public CollegeRepository(EntranceScoresContext context)
        {
            this._context = context;
        }

        public async Task<CollegeEntity> findByCode(string code)
        {
            return await Task.Run(() => this._context.collegeEntities.FindAsync(code));
        }

        public async Task<IEnumerable<CollegeEntity>> GetAll()
        {
            return await Task.Run(() => _context.collegeEntities);
        }
    }
}
