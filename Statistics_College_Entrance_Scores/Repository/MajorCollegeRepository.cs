using Crawl_College_Entrance_Scores;
using Crawl_College_Entrance_Scores.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Repository
{
    public interface IMajorCollegeRepository
    {
        Task<List<MajorCollege>> GetMajorCollegesByMajorCodeAndYear(string code, int year);
        Task<List<MajorCollege>> GetMajorCollegesByCollegeCodeAndYear(string code, int year);
        List<MajorCollege> findScoreByCollegeCompared(string majorCode, IList<string> collegeCodes, int year);
        double[] GetPastYearsTrainData();
        List<CollegeEntity> GetCollegeByGroupCode(string groupCode);
        List<MajorEntity> GetMajorByGroupCode(string groupCode);
        double[] GetScores(string majorCode, string collegeCode, double[] years);
    }
    public class MajorCollegeRepository : IMajorCollegeRepository
    {
        private readonly EntranceScoresContext _context;
        public MajorCollegeRepository(EntranceScoresContext context)
        {
            this._context = context;
        }

        public async Task<List<MajorCollege>> GetMajorCollegesByCollegeCodeAndYear(string code, int year)
        {
            return await Task.Run(() => this._context.majorColleges.Where(c => c.CollegeEntityId.Equals(code) && c.year.Equals(year)).ToList());
        }

        public async Task<List<MajorCollege>> GetMajorCollegesByMajorCodeAndYear(string code, int year)
        {
            return await Task.Run(() =>  this._context.majorColleges.Where(c => c.MajorEntityId.Equals(code) && c.year.Equals(year)).ToList());
        }

        public List<MajorCollege> findScoreByCollegeCompared(string majorCode, IList<string> collegeCodes, int year)
        {
            var rs = new List<MajorCollege>();
            foreach (var code in collegeCodes)
            {
                var majorCollegeTemp = this._context.majorColleges.Where(c => c.MajorEntityId.Equals(majorCode) && c.CollegeEntityId.Equals(code) && c.year.Equals(year)).FirstOrDefault() ;
                rs.Add(majorCollegeTemp);
            }

            return rs;
        }

        public double[] GetPastYearsTrainData()
        {
            var yearsQuery = _context.majorColleges.GroupBy(
                c => new { c.year }).Select(g => new
                {
                    g.Key.year
                }).OrderBy(x => x.year).ToList();

            double[] years = new double[yearsQuery.Count];

          
            for(int i = 0; i < yearsQuery.Count; i++)
            {
                years[i] = yearsQuery[i].year;
            }

            return years;
        }

        public double[] GetScores(string majorCode, string collegeCode, double[] years)
        {
            var rs = this._context.majorColleges.Where(
                c => c.MajorEntityId.Equals(majorCode) &&
                c.CollegeEntityId.Equals(collegeCode) && c.year >= years[0] &&
                c.year <= years[years.Length-1]).OrderBy(c=>c.year).Select(s => s.score).ToArray();
            return rs;
        }

        public List<CollegeEntity> GetCollegeByGroupCode(string groupCode)
        {
            var rs = this._context.majorColleges.Where(c=>c.groupCode.Replace(",", " ").IndexOf(groupCode) >= 0).Select(c => c.CollegeEntity).Distinct();
            var colleges = rs.ToList();
            return colleges;
        }
        public List<MajorEntity> GetMajorByGroupCode(string groupCode)
        {
            var rs = this._context.majorColleges.Where(c=>c.groupCode.Replace(",", " ").IndexOf(groupCode) >= 0).Select(c => c.MajorEntity).Distinct();
            var majors = rs.ToList();
            return majors;
        }

    }
}
