using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentAPP.Models
{
    public class PlayerStatistics
    {
        public int Id { get; set; }
        public int Player_Id { get; set; }
        public int PlayerTotal_Games { get; set; }
        public int PlayerTotal_Points { get; set; }
        public decimal PlayerAvgPoints_PerGame { get; set; }
        public decimal PlayerAvgWins_PerGame { get; set; }
        public int PlayerTotal_Wins { get; set; }
        public int PlayerTotal_Losses { get; set; }

        public Player Player { get; set; }
    }
}

