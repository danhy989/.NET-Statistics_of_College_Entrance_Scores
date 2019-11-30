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
        JsonMajor findScoreByMajorCode(string majorCode,IList<int> years);
        List<MajorEntity> GetAll();
        MajorEntity findByCode(string code);
        JsonMajor findScoreByCollegeCompared(string majorCode, IList<string> collegeCodes, IList<int> years);
        List<MajorEntity> GetMajorsByGroupCode(string groupCode);
    }
    public class MajorService : IMajorService
    {
        //@Autowire
        private readonly IMajorRepository _majorRepository;
        private readonly IMajorCollegeRepository _majorCollegeRepository;
        private readonly ICollegeRepository _collegeRepository;
        public MajorService(IMajorRepository majorRepository,IMajorCollegeRepository majorCollegeRepository,ICollegeRepository collegeRepository)
        {
            this._majorRepository = majorRepository;
            this._majorCollegeRepository = majorCollegeRepository;
            this._collegeRepository = collegeRepository;
        }

        public List<MajorEntity> GetAll()
        {
            return this._majorRepository.GetAll().Result.ToList();
        }

        public MajorEntity findByCode(string code)
        {
            return this._majorRepository.findByCode(code).Result;
        }

        public JsonMajor findScoreByMajorCode(string majorCode, IList<int> years)
        {
            return this.CreateJsonFindScore(majorCode, null, years, false);
        }

        public JsonMajor findScoreByCollegeCompared(string majorCode, IList<string> collegeCodes, IList<int> years)
        {
            return this.CreateJsonFindScore(majorCode,collegeCodes,years,true);
        }

        public JsonMajor CreateJsonFindScore(string majorCode, IList<string> collegeCodes, IList<int> years,Boolean compare)
        {
            var jsonMajor = new JsonMajor();
            var scoreColleges = new List<ScoreCollege>();
            var major = this._majorRepository.findByCode(majorCode).Result;
            jsonMajor.majorCode = major.code;
            jsonMajor.majorName = major.name;

            foreach (var year in years)
            {
                jsonMajor.years.Add(year);

                List<MajorCollege> majorColleges = new List<MajorCollege>();

                if (compare)
                {
                   majorColleges = this._majorCollegeRepository.findScoreByCollegeCompared(majorCode, collegeCodes, year);
                }
                else
                {
                   majorColleges = this._majorCollegeRepository.GetMajorCollegesByMajorCodeAndYear(majorCode, year).Result;
                }
                
                majorColleges.ForEach(c =>
                {
                    if (c != null)
                    {
                        // Ignore benchmarking capacity test
                        if (c.score <= 30)
                        {
                            if (scoreColleges.Count != 0 && scoreColleges.Exists(e => e.collegeCode == c.CollegeEntityId) == true)
                            {
                                //If exists add old college in list
                                var indexScoreInArr = scoreColleges.FindIndex(s => s.collegeCode == c.CollegeEntityId);
                                scoreColleges[indexScoreInArr].scores.Add(new JsonScore(year, c.score, c.groupCode));
                            }
                            else
                            {
                                var college = this._collegeRepository.findByCode(c.CollegeEntityId).Result;
                                var scoreCollege = new ScoreCollege();
                                scoreCollege.collegeCode = college.code;
                                scoreCollege.collegeName = college.name;
                                scoreCollege.scores.Add(new JsonScore(year, c.score, c.groupCode));
                                scoreColleges.Add(scoreCollege);
                            }
                        }
                    }
                });
                jsonMajor.colleges = scoreColleges;
            }
            return jsonMajor;
        }
        public List<MajorEntity> GetMajorsByGroupCode(string groupCode)
        {
            var majors = this._majorCollegeRepository.GetMajorByGroupCode(groupCode);
            return majors;
        }
    }
}
