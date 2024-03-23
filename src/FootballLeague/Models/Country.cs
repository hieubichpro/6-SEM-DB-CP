namespace Models
{
    public class Country
    {
        private int id;
        private string name;
        private string continent;

        public Country(int id, string name, string continent)
        {
            this.id = id;
            this.name = name;
            this.continent = continent;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Continent { get => continent; set => continent = value; }
    }
}