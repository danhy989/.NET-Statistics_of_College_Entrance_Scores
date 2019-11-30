using Statistics_College_Entrance_Scores.Common;
using Statistics_College_Entrance_Scores.Dto;
using Statistics_College_Entrance_Scores.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Service
{
    public interface IGuessService
    {
        IList<JsonScore> guessMajorScoreById(string majorCode, string collegeCod, IList<int> yearsGuess);
    }
    public class GuessService : IGuessService
    {
        private readonly IMajorCollegeRepository _majorCollegeRepository;
        public GuessService(IMajorCollegeRepository majorCollegeRepository)
        {
            this._majorCollegeRepository = majorCollegeRepository;
        }

        public IList<JsonScore> guessMajorScoreById(string majorCode,string collegeCode, IList<int> yearsGuess)
        {
            var yearsPastTrainData = this._majorCollegeRepository.GetPastYearsTrainData();
            var scoresPastTrainData = this._majorCollegeRepository.GetScores(majorCode, collegeCode, yearsPastTrainData);
			var guessScoreYearList = new List<JsonScore>();
            foreach(var y in yearsGuess)
            {
                var scoreGuess = LinearRegressionHelper.LinearRegression(yearsPastTrainData, scoresPastTrainData, y);
				guessScoreYearList.Add(new JsonScore(y,scoreGuess,null));
            }

            return guessScoreYearList;
        }
    }
}
