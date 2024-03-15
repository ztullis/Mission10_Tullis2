namespace Mission10_Tullis_API.Data
{
    public interface IBowlingLeagueRepository
    {
        IEnumerable<Bowler> Bowlers { get; }
        IEnumerable<Team>Teams { get; }
        IEnumerable<Bowler> GetAllBowlers();
    }
}
