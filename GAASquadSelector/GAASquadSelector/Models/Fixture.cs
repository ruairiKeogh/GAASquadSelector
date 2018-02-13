using System;

namespace GAASquadSelector.Models
{
    public struct Score
    {
        int Goals { get; set; }
        int Points { get; set; }
    }

    public class Fixture
    {
            
        int ID { get; set; }
        DateTime? Date { get; set; }
        string HomeTeam { get; set; }
        string AwayTeam { get; set; }
        Score HomeScore { get; set; }
        Score AwayScore { get; set; }
        string League { get; set; }
        string Referee { get; set; }
        string Venue { get; set; }

    }
}
