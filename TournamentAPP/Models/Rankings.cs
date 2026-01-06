using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentAPP.Models
{
    public class Rankings
    {
        public int Id { get; set; }
        public int Tournament_Id { get; set; }
        public int Player_Id { get; set; }
        public int TotalPlayer_Points { get; set; }
        public int Player_Position { get; set; }
    }
}
