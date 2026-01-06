using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentAPP.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Tournament_Name { get; set; }
        public DateTime StartTournament_Date { get; set; }
        public DateTime EndTournament_Date { get; set; }
        public bool Is_Online { get; set; }

        public List<Enrollment> Enrollments { get; set; }
        public List<TournamentRound> TournamentRounds { get; set; }
        public List<Game> Games { get; set; }
    }
}

