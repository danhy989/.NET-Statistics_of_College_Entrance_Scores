using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Dto
{
	public class GuessScoreDTO
	{
		
	}

	public class GuessYearsDTO
	{
		public GuessYearsDTO(int[] years)
		{
			this.years = years;
		}

		public int[] years { get; set; }

	}
}
