using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Statistics_College_Entrance_Scores.Common;
using Statistics_College_Entrance_Scores.Dto;
using Statistics_College_Entrance_Scores.Service;

namespace Statistics_College_Entrance_Scores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuessController : ControllerBase
    {

        private readonly IGuessService _guessService;
        public GuessController(IGuessService guessService)
        {
            this._guessService = guessService;
        }

         [HttpGet]
        public IActionResult GuessMajorScore()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();


            this._guessService.guessMajorScoreById("7340101","KHA",new int[] { 2020,2021});



            watch.Stop();
            var took = watch.ElapsedMilliseconds;
            return Ok(new JsonResponse(took, null, 0));
        }
    }
}