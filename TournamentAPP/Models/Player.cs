using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentAPP.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Player_Name { get; set; }
        public string Player_Age { get; set; }
        public string Player_DateOfBirth { get; set; }
        public string Player_Phone { get; set; }
        public string Player_Email { get; set; }
        public string Player_Country { get; set; }
        public int User_Id { get; set; }

        public User User { get; set; }
        public PlayerStatistics PlayerStatistics { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<GamePlayerResults> GamePlayerResults { get; set; }
    }
}

