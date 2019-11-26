using Crawl_College_Entrance_Scores.entity;
using Statistics_College_Entrance_Scores.Dto;
using Statistics_College_Entrance_Scores.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Service
{
    public interface ICollegeService
    {
        JsonCollege findScoreByCollegeCode(string code, int year);
        List<CollegeEntity> GetAll();
        CollegeEntity findByCode(string code);
    }
    public class CollegeService : ICollegeService
    {
        private readonly IMajorRepository _majorRepository;
        private readonly IMajorCollegeRepository _majorCollegeRepository;
        private readonly ICollegeRepository _collegeRepository;
        public CollegeService(IMajorRepository majorRepository, IMajorCollegeRepository majorCollegeRepository, ICollegeRepository collegeRepository)
        {
            this._majorRepository = majorRepository;
            this._majorCollegeRepository = majorCollegeRepository;
            this._collegeRepository = collegeRepository;
        }

        public CollegeEntity findByCode(string code)
        {
            return this._collegeRepository.findByCode(code).Result;
        }

        public JsonCollege findScoreByCollegeCode(string code, int year)
        {
            var scoreMajors = new List<ScoreMajor>();
            var jsonCollege = new JsonCollege();
            var majorColleges = this._majorCollegeRepository.GetMajorCollegesByCollegeCodeAndYear(code, year).Result;
            majorColleges.ForEach(c =>
            {
                var major = this._majorRepository.findByCode(c.MajorEntityId).Result;
                var scoreMajor = new ScoreMajor();
                scoreMajor.majorCode = major.code;
                scoreMajor.majorName = major.name;
                scoreMajor.groupCode = c.groupCode;
                scoreMajor.score = c.score;
                scoreMajors.Add(scoreMajor);
            });
            var college = this._collegeRepository.findByCode(code).Result;

            jsonCollege.collegeCode = college.code;
            jsonCollege.collegeName = college.name;
            jsonCollege.year = year;
            jsonCollege.majors = scoreMajors;

            return jsonCollege;
        }

        public List<CollegeEntity> GetAll()
        {
            return this._collegeRepository.GetAll().Result.ToList();
        }
    }
}
