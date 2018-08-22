namespace CongressusCore.Areas.Users.Models {
    public class User {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string passwordHash { get; set; }
        public string noce { get;set; }
    }
}