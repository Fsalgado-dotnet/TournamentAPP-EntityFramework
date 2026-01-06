using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentAPP.Models
{
    public class GamePlayerResults
    {
        public int Id { get; set; }
        public int Game_Id { get; set; }
        public int Player_Id { get; set; }
        public int GamePlayer_Score { get; set; }
        public bool Is_Winner { get; set; }

        public Player Player { get; set; }
        public Game Game { get; set; }
    }
}
