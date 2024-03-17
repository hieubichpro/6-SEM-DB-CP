namespace Models
{
    public class Feedback
    {
        private int id;
        private string comment;
        private int grade;
        private int idUser;
        private int idLeague;

        Feedback(int id, string comment, int grade, int id_user, int id_league)
        {
            this.id = id;
            this.comment = comment;
            this.grade = grade;
            this.idUser = id_user;
            this.idLeague = id_league;
        }

        public int Id { get => id; set => id = value; }
        public string Comment { get => comment; set => comment = value; }
        public int Grade { get => grade; set => grade = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public int IdLeague { get => idLeague; set => idLeague = value; }
    }
}