using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentAPP.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Round_Id { get; set; }
        public int Tournament_Id { get; set; }
        public DateTime StartGame_Date { get; set; }
        public DateTime? EndGame_Date { get; set; }
        public string Game_Local { get; set; }
        public string Game_State { get; set; }
        public string GameStreaming_Link { get; set; }

        public Round Round { get; set; }
        public Tournament Tournament { get; set; }
        public List<GamePlayerResults> GamePlayerResults { get; set; }
    }
}

