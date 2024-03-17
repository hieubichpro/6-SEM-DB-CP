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

        User(int id, string login, string password, string role, string firstName, string lastName, int age)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.role = role;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
    }
}
