using Crawl_College_Entrance_Scores;
using Crawl_College_Entrance_Scores.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Repository
{
    public interface IMajorRepository
    {
       Task<IEnumerable<MajorEntity>> GetAll();
       Task<MajorEntity> findByCode(string code);
    }
    public class MajorRepository : IMajorRepository
    {
        private readonly EntranceScoresContext _context;

        public MajorRepository(EntranceScoresContext context)
        {
            this._context = context;
        }

        public async Task<MajorEntity> findByCode(string code)
        {
            return await Task.Run(() => this._context.majorEntities.FindAsync(code));
        }

        public async Task<IEnumerable<MajorEntity>> GetAll()
        {
            return await Task.Run(() => _context.majorEntities);
        }

    }
}
