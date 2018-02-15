using System;
using System.ComponentModel.DataAnnotations;

namespace GAASquadSelector.Models
{
    public struct Score
    {
        int Goals { get; set; }
        int Points { get; set; }
    }

    public class Fixture
    {
        [Key]
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public Score HomeScore { get; set; }
        public Score AwayScore { get; set; }
        public string League { get; set; }
        public string Referee { get; set; }
        public string Venue { get; set; }

    }
}
