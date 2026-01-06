using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentAPP.Models
{
    public class TournamentRound
    {
        public int Id { get; set; }
        public int Tournament_Id { get; set; }
        public int Round_Id { get; set; }
    }
}
