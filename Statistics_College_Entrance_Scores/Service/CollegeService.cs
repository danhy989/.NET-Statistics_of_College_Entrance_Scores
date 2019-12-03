using Statistics_College_Entrance_Scores.entity;
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
        JsonCollege findScoreByCollegeCode(string code, IList<int> years);
        List<CollegeEntity> GetAll();
        CollegeEntity findByCode(string code);
        List<CollegeEntity> GetCollegeByProvince(long province_id);
        List<CollegeEntity> GetCollegeByGroupCode(string groupCode);
        List<CollegeEntity> GetCollegesByName(string name);
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

        public JsonCollege findScoreByCollegeCode(string code, IList<int> years)
        {
            var scoreMajors = new List<ScoreMajor>();
            var jsonCollege = new JsonCollege();
            var college = this._collegeRepository.findByCode(code).Result;

            jsonCollege.collegeCode = college.code;
            jsonCollege.collegeName = college.name;

            foreach (var year in years)
            {
                jsonCollege.years.Add(year);

                var majorColleges = this._majorCollegeRepository.GetMajorCollegesByCollegeCodeAndYear(code, year).Result;
                majorColleges.ForEach(c =>
                {
                    // Ignore benchmarking capacity shiken
                    if (c.score <= 30)
                    {
                        if (scoreMajors.Count != 0 && scoreMajors.Exists(e => e.majorCode == c.MajorEntityId) == true)
                        {
                            //If exists add old college in list
                            var indexScoreInArr = scoreMajors.FindIndex(s => s.majorCode == c.MajorEntityId);
                            scoreMajors[indexScoreInArr].scores.Add(new JsonScore(year, c.score, c.groupCode));
                        }
                        else
                        {
                            var major = this._majorRepository.findByCode(c.MajorEntityId).Result;
                            var scoreMajor = new ScoreMajor();
                            scoreMajor.majorCode = major.code;
                            scoreMajor.majorName = major.name;
                            scoreMajor.scores.Add(new JsonScore(year, c.score, c.groupCode));
                            scoreMajors.Add(scoreMajor);
                        }
                    }

                });
                jsonCollege.majors = scoreMajors;
            }

            return jsonCollege;
        }


        public List<CollegeEntity> GetAll()
        {
            return this._collegeRepository.GetAll().Result.ToList();
        }

        public List<CollegeEntity> GetCollegeByProvince(long province_id)
        {
            return this._collegeRepository.GetByProvince(province_id).Result;
        }
        public List<CollegeEntity> GetCollegeByGroupCode(string groupCode)
        {
            var colleges = this._majorCollegeRepository.GetCollegeByGroupCode(groupCode);
            return colleges;
        }
        public List<CollegeEntity> GetCollegesByName(string name)
        {
            var colleges = this._collegeRepository.GetByName(name).Result;
            return colleges;
        }
    }
}
