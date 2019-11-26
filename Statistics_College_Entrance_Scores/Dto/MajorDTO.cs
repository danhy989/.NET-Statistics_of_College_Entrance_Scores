using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawl_College_Entrance_Scores.entity;

namespace Crawl_College_Entrance_Scores.dto
{
    public class MajorDTO
    {
        public MajorDTO(string majorCode, int year)
        {
            this.majorCode = majorCode;
            this.year = year;
        }

        public string majorCode { get; set; }
        public int year { get; set; }
    }
}