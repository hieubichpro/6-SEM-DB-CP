namespace Models
{
    public class Match
    {
        private int id;
        private int goalHomeTeam;
        private int goalGuessTeam;
        private int idLeague;
        private int idHomeTeam;
        private int idGuessTeam;
        private int idStadium;

        public Match(int id, int goalHomeTeam, int goalGuessTeam, int idLeague, int idHomeTeam, int idGuessTeam, int idStadium)
        {
            this.id = id;
            this.goalHomeTeam = goalHomeTeam;
            this.goalGuessTeam = goalGuessTeam;
            this.idLeague = idLeague;
            this.idHomeTeam = idHomeTeam;
            this.idGuessTeam = idGuessTeam;
            this.idStadium = idStadium;
        }

        public int Id { get => id; set => id = value; }
        public int GoalHomeTeam { get => goalHomeTeam; set => goalHomeTeam = value; }
        public int GoalGuessTeam { get => goalGuessTeam; set => goalGuessTeam = value; }
        public int IdLeague { get => idLeague; set => idLeague = value; }
        public int IdHomeTeam { get => idHomeTeam; set => idHomeTeam = value; }
        public int IdGuessTeam { get => idGuessTeam; set => idGuessTeam = value; }
        public int IdStadium { get => idStadium; set => idStadium = value; }
    }
}