﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Dto
{
	public class GuessScoreDTO
	{
		public GuessScoreDTO(string collegeCode, string majorCode, string groupCode, int[] years)
		{
			this.collegeCode = collegeCode;
			this.majorCode = majorCode;
			this.groupCode = groupCode;
			this.years = years;
		}

		public string collegeCode { get; set; }
		public string majorCode { get; set; }
		public string groupCode { get; set; }
		public int[] years { get; set; }
	}
}
