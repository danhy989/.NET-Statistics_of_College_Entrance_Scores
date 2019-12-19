using Statistics_College_Entrance_Scores.Repository;
using Statistics_College_Entrance_Scores.entity;
using System.Collections.Generic;

namespace Statistics_College_Entrance_Scores.Service
{
    public interface IMajorCollegeService
    {
        int[] GetYears();
        List<MajorEntity> FindMajorAndCollegeByName(string name);
    }
    public class MajorCollegeService : IMajorCollegeService
    {
        private readonly IMajorCollegeRepository _majorCollegeRepository;
        public MajorCollegeService(IMajorCollegeRepository majorCollegeRepository)
        {
            this._majorCollegeRepository = majorCollegeRepository;
        }

        public int[] GetYears()
        {
            return this._majorCollegeRepository.GetYears();
        }

        public List<MajorEntity> FindMajorAndCollegeByName(string name)
        {
            var majors = _majorCollegeRepository.FindMajorAndCollegeByName(name).Result;
            return majors;
        }
    }
}
