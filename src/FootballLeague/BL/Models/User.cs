namespace Models
{
    public class User
    {
        private int id;
        private string login;
        private string password;
        private string role;
        private string firstName;
        private string lastName;
        private int age;
        private int idClub;

        public User(string login, string password, string role, string firstName, string lastName, int age, int idClub = -1, int id = 1)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.role = role;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.idClub = idClub;
        }

        public User(string role)
        {
            this.role = role;
            this.id = 100;
        }

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public int IdClub { get => idClub; set => idClub = value; }

        public bool checkPassword(string password)
        {
            return this.password == password;
        }
    }
}
