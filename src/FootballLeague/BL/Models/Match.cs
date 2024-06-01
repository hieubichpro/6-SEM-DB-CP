using System;

namespace Models
{
    public class Match
    {
        private int id;
        private int goalHomeTeam;
        private int goalGuestTeam;
        private int idLeague;
        private int idHomeTeam;
        private int idGuestTeam;
        private int idStadium;
        private string timeStart;
        private int week;
        public Match(int idLeague, int idHomeTeam, int idGuestTeam, int idStadium, string timeStart, int week, int goalHomeTeam = 1, int goalGuestTeam = 1, int id = 1)
        {
            this.id = id;
            this.goalHomeTeam = goalHomeTeam;
            this.goalGuestTeam = goalGuestTeam;
            this.idLeague = idLeague;
            this.idHomeTeam = idHomeTeam;
            this.idGuestTeam = idGuestTeam;
            this.idStadium = idStadium;
            this.timeStart = timeStart;
            this.Week = week;
        }

        public int Id { get => id; set => id = value; }
        public int GoalHomeTeam { get => goalHomeTeam; set => goalHomeTeam = value; }
        public int GoalGuestTeam { get => goalGuestTeam; set => goalGuestTeam = value; }
        public int IdLeague { get => idLeague; set => idLeague = value; }
        public int IdHomeTeam { get => idHomeTeam; set => idHomeTeam = value; }
        public int IdGuestTeam { get => idGuestTeam; set => idGuestTeam = value; }
        public int IdStadium { get => idStadium; set => idStadium = value; }
        public int Week { get => week; set => week = value; }
        public string TimeStart { get => timeStart; set => timeStart = value; }
    }
}