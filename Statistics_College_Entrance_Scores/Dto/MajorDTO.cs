using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Statistics_College_Entrance_Scores.entity;

namespace Statistics_College_Entrance_Scores.dto
{
    public class MajorDTO
    {
        public MajorDTO(string majorCode, IList<int> years)
        {
            this.majorCode = majorCode;
            this.years = years;
        }

        public string majorCode { get; set; }
        public IList<int> years { get; set; }
    }
}