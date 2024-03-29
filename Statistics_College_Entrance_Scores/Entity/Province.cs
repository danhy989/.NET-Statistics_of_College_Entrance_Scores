﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.entity
{
	public class Province
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public long province_id { get; set; }
		public string name { get; set; }
		public ICollection<CollegeEntity> collegeEntities { get; set; }
		public Province() { }
		
	}
}
