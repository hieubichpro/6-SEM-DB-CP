namespace Models
{
    public class Stadium
    {
        private int id;
        private string name;
        private int capacity;
        private int idCountry;
        public Stadium(string name, int capacity, int idCountry, int id = 1)
        {
            this.id = id;
            this.name = name;
            this.capacity = capacity;
            this.idCountry = idCountry;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int IdCountry { get => idCountry; set => idCountry = value; }
    }
}