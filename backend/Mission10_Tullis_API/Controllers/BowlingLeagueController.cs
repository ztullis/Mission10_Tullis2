using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10_Tullis_API.Data;

namespace Mission10_Tullis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingLeagueController : ControllerBase
    {
        private IBowlingLeagueRepository _BowlingRepository;

        public BowlingLeagueController(IBowlingLeagueRepository temp)
        {
            _BowlingRepository = temp;
        }

        [HttpGet]
        public IEnumerable<Bowler> Get()
        {
            var bowlerData = _BowlingRepository.GetAllBowlers()
                .Where(x => x.Team.TeamName == "Marlins" || x.Team.TeamName == "Sharks");

            return bowlerData;
        }
    }
}
