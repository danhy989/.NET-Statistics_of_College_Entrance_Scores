using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Statistics_College_Entrance_Scores.Dto;
using Statistics_College_Entrance_Scores.Service;

namespace Statistics_College_Entrance_Scores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorCollegeController : ControllerBase
    {
        private readonly IMajorCollegeService _majorCollegeService;

        public MajorCollegeController(IMajorCollegeService majorCollegeService)
        {
            _majorCollegeService = majorCollegeService;
        }

        [HttpGet("years")]
        public IActionResult GetYears()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var rs = this._majorCollegeService.GetYears();
            watch.Stop();
            var took = watch.ElapsedMilliseconds;
            return Ok(new JsonResponse(took, null, rs));
        }
    }


}