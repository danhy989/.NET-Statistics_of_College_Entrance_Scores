using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Dto
{
    public class JsonScore
    {
        public JsonScore()
        {

        }

        public JsonScore(int year, double score, string groupCode)
        {
            this.year = year;
            this.score = score;
            this.groupCode = groupCode;
        }

        public int year { get; set; }
        public double score { get; set; }
        public string groupCode { get; set; }
    }
}
