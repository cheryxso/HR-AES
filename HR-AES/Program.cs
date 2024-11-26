using System;
using UserManagement.Models;
using UserManagement.Services;

class Program
{
    static void Main(string[] args)
    {
        var adminService = new AdminService();

        // Демонстрація роботи
        Console.WriteLine("=== Адміністраторська панель ===");

        // Створення користувачів
        Console.WriteLine("Створення користувачів...");
        adminService.CreateUser("manager1", "pass123", UserType.HRManager);
        adminService.CreateUser("employee1", "word123", UserType.HREmployee);
        adminService.CreateUser("aesworker1", "password123", UserType.AESEmployee);

        // Виведення списку користувачів
        Console.WriteLine("\nСписок користувачів:");
        foreach (var user in adminService.GetAllUsers())
        {
            Console.WriteLine(user);
        }

        // Видалення користувача
        Console.WriteLine("\nВидалення користувача 'employee1'...");
        adminService.DeleteUser("employee1");

        // Виведення списку користувачів після видалення
        Console.WriteLine("\nСписок користувачів після видалення:");
        foreach (var user in adminService.GetAllUsers())
        {
            Console.WriteLine(user);
        }

        // Налаштування прав доступу
        Console.WriteLine("\nДеактивація користувача 'aesworker1'...");
        adminService.SetUserAccess("aesworker1", false);

        // Виведення списку користувачів після налаштування доступу
        Console.WriteLine("\nСписок користувачів після налаштування доступу:");
        foreach (var user in adminService.GetAllUsers())
        {
            Console.WriteLine(user);
        }
    }
}

