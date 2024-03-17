namespace Models
{
    public class Club
    {
        private int id;
        private string name;
        private int idUser;
        private int idCountry;

        Club(int id, string name, int idStadium, int idUser, int idCountry)
        {
            this.id = id;
            this.name = name;
            this.idUser = idUser;
            this.idCountry = idCountry;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public int IdCountry { get => idCountry; set => idCountry = value; }
    }
}