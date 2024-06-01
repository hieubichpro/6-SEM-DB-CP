namespace Models
{
    public class League
    {
        private int id;
        private string name;
        private double rating;
        private int idUser;
        private int idCountry;

        public League(string name, double rating, int idUser, int idCountry, int id = 1)
        {
            this.id = id;
            this.name = name;
            this.rating = rating;
            this.idUser = idUser;
            this.idCountry = idCountry;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Rating { get => rating; set => rating = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public int IdCountry { get => idCountry; set => idCountry = value; }
    }
}