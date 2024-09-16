using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    // Pre-defined transactions
    static List<string> transactions = new List<string> { "Para Çekme", "Para Yatırma", "Ödeme Yapma" };

    // User storage and transaction log
    static Dictionary<string, string> registeredUsers = new Dictionary<string, string>
    {
        {"user1", "password1"},
        {"user2", "password2"}
    };

    static List<string> transactionLogs = new List<string>();
    static List<string> fraudLogs = new List<string>();

    static void Main()
    {
        Console.WriteLine("ATM Uygulamasına Hoşgeldiniz");

        // User login
        Console.WriteLine("Kullanıcı adınızı girin:");
        string username = Console.ReadLine();

        Console.WriteLine("Şifrenizi girin:");
        string password = Console.ReadLine();

        if (!IsValidUser(username, password))
        {
            Console.WriteLine("Geçersiz kullanıcı adı veya şifre.");
            fraudLogs.Add($"Geçersiz giriş denemesi: {username} - {DateTime.Now}");
            return;
        }

        // Main menu
        while (true)
        {
            Console.WriteLine("\nYapmak istediğiniz işlemi seçin:");
            for (int i = 0; i < transactions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {transactions[i]}");
            }
            Console.WriteLine($"{transactions.Count + 1}. Gün Sonu");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= transactions.Count + 1)
            {
                if (choice == transactions.Count + 1)
                {
                    EndOfDay();
                    break;
                }
                PerformTransaction(transactions[choice - 1]);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
            }
        }
    }

    static bool IsValidUser(string username, string password)
    {
        return registeredUsers.ContainsKey(username) && registeredUsers[username] == password;
    }

    static void PerformTransaction(string transactionType)
    {
        Console.WriteLine($"İşlem türü: {transactionType}");

        // Dummy implementation of transaction
        Console.WriteLine("İşlem başarıyla gerçekleştirildi.");
        transactionLogs.Add($"{transactionType} işlemi: {DateTime.Now}");
    }

    static void EndOfDay()
    {
        Console.WriteLine("Gün sonu işlemleri yapılıyor...");

        string fileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            sw.WriteLine("Gün Sonu Raporu");
            sw.WriteLine("İşlem Günlüğü:");
            foreach (var log in transactionLogs)
            {
                sw.WriteLine(log);
            }

            sw.WriteLine("\nFraud Logları:");
            foreach (var fraud in fraudLogs)
            {
                sw.WriteLine(fraud);
            }
        }

        Console.WriteLine($"Gün sonu raporu '{fileName}' dosyasına yazıldı.");
    }
}
