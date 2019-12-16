using Statistics_College_Entrance_Scores.Repository;

namespace Statistics_College_Entrance_Scores.Service
{
    public interface IMajorCollegeService
    {
        int[] GetYears();
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
    }
}
