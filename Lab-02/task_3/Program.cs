using System;

// Клас Authenticator, реалізований як Singleton
public sealed class Authenticator
{
    // Статичне поле для зберігання єдиного екземпляра
    private static Authenticator _instance;

    // Об'єкт для блокування, щоб забезпечити потокобезпеку
    private static readonly object _lock = new object();

    // Приватний конструктор, щоб заборонити створення нових екземплярів
    private Authenticator()
    {
        // Можна додати ініціалізацію ресурсів тут
    }

    // Метод для отримання єдиного екземпляра
    public static Authenticator GetInstance()
    {
        // Використання блокування для потокобезпеки
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Authenticator();
                }
            }
        }
        return _instance;
    }

    // Метод для аутентифікації користувачів (приклад функціоналу)
    public bool Authenticate(string username, string password)
    {
        // Простий приклад аутентифікації
        return username == "admin" && password == "password123";
    }
}

// Головний метод програми для перевірки коду
public class Program
{
    public static void Main()
    {
        // Отримання єдиного екземпляра Authenticator
        Authenticator auth1 = Authenticator.GetInstance();
        Authenticator auth2 = Authenticator.GetInstance();

        // Перевірка, чи це один і той самий екземпляр
        Console.WriteLine("Are both instances the same? " + (auth1 == auth2)); // True

        // Перевірка аутентифікації
        bool isAuthenticated = auth1.Authenticate("admin", "password123");
        Console.WriteLine("Is user authenticated? " + isAuthenticated); // True
    }
}
