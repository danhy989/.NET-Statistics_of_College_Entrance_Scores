using Crawl_College_Entrance_Scores.entity;
using Statistics_College_Entrance_Scores.Dto;
using Statistics_College_Entrance_Scores.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Service
{

    public interface IMajorService
    {
        JsonMajor findScoreByMajorCode(string majorCode,int year);
        List<MajorEntity> GetAll();
        MajorEntity findByCode(string code);
    }
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository _majorRepository;
        private readonly IMajorCollegeRepository _majorCollegeRepository;
        private readonly ICollegeRepository _collegeRepository;
        public MajorService(IMajorRepository majorRepository,IMajorCollegeRepository majorCollegeRepository,ICollegeRepository collegeRepository)
        {
            this._majorRepository = majorRepository;
            this._majorCollegeRepository = majorCollegeRepository;
            this._collegeRepository = collegeRepository;
        }

        public MajorEntity findByCode(string code)
        {
            return this._majorRepository.findByCode(code).Result;
        }

        public JsonMajor findScoreByMajorCode(string majorCode, int year)
        {
            var scoreColleges = new List<ScoreCollege>();
            var jsonMajor = new JsonMajor();
            var majorColleges = this._majorCollegeRepository.GetMajorCollegesByMajorCodeAndYear(majorCode, year).Result;
            majorColleges.ForEach(c =>
            {
                var college = this._collegeRepository.findByCode(c.CollegeEntityId).Result;
                var scoreCollege = new ScoreCollege();
                scoreCollege.collegeCode = college.code;
                scoreCollege.collegeName = college.name;
                scoreCollege.groupCode = c.groupCode;
                scoreCollege.score = c.score;
                scoreColleges.Add(scoreCollege);
            });
            var major = this._majorRepository.findByCode(majorCode).Result;

            jsonMajor.majorCode = major.code;
            jsonMajor.majorName = major.name;
            jsonMajor.year = year;
            jsonMajor.colleges = scoreColleges;

            return jsonMajor;
        }

        public List<MajorEntity> GetAll()
        {
            return this._majorRepository.GetAll().Result.ToList();
        }
    }
}
