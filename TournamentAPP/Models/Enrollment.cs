using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentAPP.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int Player_Id { get; set; }
        public DateTime Enrollment_Date { get; set; }
        public bool Is_Approved { get; set; }
        public int Tournament_Id { get; set; }

        public Player Player { get; set; }
        public Tournament Tournament { get; set; }
    }
}

