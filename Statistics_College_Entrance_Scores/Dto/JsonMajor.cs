using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Dto
{

    public class ScoreCollege
    {
        public ScoreCollege()
        {
        }

        public ScoreCollege(string collegeCode, string collegeName, string groupCode, double score)
        {
            this.collegeCode = collegeCode;
            this.collegeName = collegeName;
            this.groupCode = groupCode;
            this.score = score;
        }

        public string collegeCode { get; set; }
        public string collegeName { get; set; }
        public string groupCode { get; set; }
        public double score { get; set; }
    }
    public class JsonMajor
    {
        public JsonMajor()
        {
        }

        public JsonMajor(string majorCode, string majorName, int year, IEnumerable<ScoreCollege> colleges)
        {
            this.majorCode = majorCode;
            this.majorName = majorName;
            this.year = year;
            this.colleges = colleges;
        }

        public string majorCode { get; set; }
        public string majorName { get; set; }
        public int year { get; set; }
        public IEnumerable<ScoreCollege> colleges { get; set; }
    }
}
