
namespace Mission10_Tullis_API.Data
{
    public class EFBowlingLeagueRepository : IBowlingLeagueRepository
    {
        private BowlingLeagueContext _context;
        public EFBowlingLeagueRepository(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers;

        public IEnumerable<Team> Teams => _context.Teams;

        public IEnumerable<Bowler> GetAllBowlers()
        {
            var joinedData = from bowler in _context.Bowlers
                             join team in _context.Teams
                             on bowler.TeamID equals team.TeamID
                             select new
                             {
                                 BowlerID = bowler.BowlerID,
                                 BowlerFirstName = bowler.BowlerFirstName,
                                 BowlerLastName = bowler.BowlerLastName,
                                 BowlerMiddleInit = bowler.BowlerMiddleInit,
                                 BowlerAddress = bowler.BowlerAddress,
                                 BowlerCity = bowler.BowlerCity,
                                 BowlerState = bowler.BowlerState,
                                 BowlerZip = bowler.BowlerZip,
                                 BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                                 TeamID = bowler.TeamID,
                                 TeamID2 = team.TeamID,
                                 TeamName = team.TeamName,
                                 CaptainID = team.CaptainID
                             };

            var bowlersWithTeams = joinedData
                .Select(b => new Bowler
                {
                    BowlerID = b.BowlerID,
                    BowlerFirstName = b.BowlerFirstName,
                    BowlerLastName = b.BowlerLastName,
                    BowlerMiddleInit = b.BowlerMiddleInit,
                    BowlerAddress = b.BowlerAddress,
                    BowlerCity = b.BowlerCity,
                    BowlerState = b.BowlerState,
                    BowlerZip = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber,
                    TeamID = b.TeamID,
                    Team = new Team { TeamName = b.TeamName , TeamID = b.TeamID2, CaptainID = b.CaptainID}
                })
                .ToList();

            return bowlersWithTeams;
        }

        public void GetAllBowlers(Bowler bowler)
        {
            throw new NotImplementedException();
        }
    }
}
