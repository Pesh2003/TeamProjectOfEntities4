namespace ConsoleTestApplication01
{
    internal class User
    {
        internal User(int id, string username, string password, string description, int userTypeId)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Description = description;
            this.UserTypeId = userTypeId;

        }

        internal int Id { get; set; }
        internal string Username { get; set; }
        internal string Password { get; set; }
        internal string Description { get; set; }
        internal int UserTypeId { get; set; }
    }
}
