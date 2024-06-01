namespace Models
{
    public class Club
    {
        private int id;
        private string name;
        private int idCountry;

        public Club(string name, int idCountry, int id = 1)
        {
            this.Id = id;
            this.Name = name;
            this.IdCountry = idCountry;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdCountry { get => idCountry; set => idCountry = value; }
    }
}