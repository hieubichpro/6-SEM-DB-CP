namespace Models
{
    public class Feedback
    {
        private int id;
        private int grade;
        private int idUser;
        private int idLeague;

        public Feedback(int grade, int id_user, int id_league, int id = 1)
        {
            this.id = id;
            this.grade = grade;
            this.idUser = id_user;
            this.idLeague = id_league;
        }

        public int Id { get => id; set => id = value; }
        public int Grade { get => grade; set => grade = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public int IdLeague { get => idLeague; set => idLeague = value; }
    }
}