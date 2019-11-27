﻿using Crawl_College_Entrance_Scores;
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
    }
}
