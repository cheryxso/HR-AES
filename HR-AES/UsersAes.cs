namespace UserManagement.Models
{
    public enum UserType
    {
        HRManager,
        HREmployee,
        AESEmployee
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } 
        public UserType Type { get; set; }
        public bool IsActive { get; set; } = true;

        public User(string username, string password, UserType type)
        {
            Username = username;
            Password = password;
            Type = type;
        }

        public override string ToString()
        {
            return $"Username: {Username}, Type: {Type}, Active: {IsActive}";
        }
    }
}
