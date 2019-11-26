using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Dto
{
    public class ScoreMajor
    {
        public ScoreMajor()
        {
        }

        public ScoreMajor(string majorCode, string majorName, string groupCode, double score)
        {
            this.majorCode = majorCode;
            this.majorName = majorName;
            this.groupCode = groupCode;
            this.score = score;
        }

        public string majorCode { get; set; }
        public string majorName { get; set; }
        public string groupCode { get; set; }
        public double score { get; set; }
    }
    public class JsonCollege
    {
        public JsonCollege()
        {
        }

        public JsonCollege(string collegeCode, string collegeName, int year, IEnumerable<ScoreMajor> majors)
        {
            this.collegeCode = collegeCode;
            this.collegeName = collegeName;
            this.year = year;
            this.majors = majors;
        }

        public string collegeCode { get; set; }
        public string collegeName { get; set; }
        public int year { get; set; }
        public IEnumerable<ScoreMajor> majors { get; set; }
    }
}
