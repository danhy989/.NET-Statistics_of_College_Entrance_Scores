using Statistics_College_Entrance_Scores.Common;
using Statistics_College_Entrance_Scores.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Service
{
    public interface IGuessService
    {
        double guessMajorScoreById(string majorCode, string collegeCod, IList<int> yearsGuess);
        double guessMajorScoreById(string code, int year);
    }
    public class GuessService : IGuessService
    {
        private readonly IMajorCollegeRepository _majorCollegeRepository;
        public GuessService(IMajorCollegeRepository majorCollegeRepository)
        {
            this._majorCollegeRepository = majorCollegeRepository;
        }
        
        public double guessMajorScoreById(string code, int year)
        {
            var years = this._majorCollegeRepository.GetPastYearsTrainData();
            return 0;
        }

        public double guessMajorScoreById(string majorCode,string collegeCode, IList<int> yearsGuess)
        {
            var years = this._majorCollegeRepository.GetPastYearsTrainData();
            var scores = this._majorCollegeRepository.GetScores(majorCode, collegeCode, years);
            foreach(var y in yearsGuess)
            {
                var scoreGuess = LinearRegressionHelper.LinearRegression(years, scores, y);
                //New object p2
            }

            return 0;
        }
    }
}
