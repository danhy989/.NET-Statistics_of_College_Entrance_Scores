using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawl_College_Entrance_Scores.entity;

namespace Crawl_College_Entrance_Scores.dto
{
    public class CollegeDTO
    {
        public CollegeDTO(string collegeCode, int year)
        {
            this.collegeCode = collegeCode;
            this.year = year;
        }

        public string collegeCode { get; set; }
        public int year { get; set; }
    }
}