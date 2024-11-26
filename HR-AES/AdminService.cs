using UserManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserManagement.Services
{
    public class AdminService
    {
        private readonly List<User> _users = new List<User>();

        // Створення користувача
        public bool CreateUser(string username, string password, UserType type)
        {
            if (_users.Any(u => u.Username == username))
            {
                return false; // Логін уже існує
            }

            var newUser = new User(username, password, type);
            _users.Add(newUser);
            return true;
        }

        // Видалення користувача
        public bool DeleteUser(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return false; // Користувач не знайдений
            }

            _users.Remove(user);
            return true;
        }

        // Налаштування прав доступу (активація/деактивація користувача)
        public bool SetUserAccess(string username, bool isActive)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return false; // Користувач не знайдений
            }

            user.IsActive = isActive;
            return true;
        }

        // Отримання списку користувачів
        public List<User> GetAllUsers()
        {
            return _users;
        }
    }
}

