using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Pre-defined categories
    static List<string> categories = new List<string>
    {
        "Film Kategorileri",
        "Tech Stack Kategorileri",
        "Spor Kategorileri"
    };

    // User storage
    static HashSet<string> registeredUsers = new HashSet<string>();
    
    // Votes storage
    static Dictionary<string, int> votes = new Dictionary<string, int>();

    static void Main()
    {
        // Initialize votes dictionary with categories
        foreach (var category in categories)
        {
            votes[category] = 0;
        }

        while (true)
        {
            Console.WriteLine("Giriş yapmak için kullanıcı adınızı girin (Çıkmak için 'exit' yazın):");
            string username = Console.ReadLine();

            if (username.ToLower() == "exit")
                break;

            if (!registeredUsers.Contains(username))
            {
                Console.WriteLine("Kullanıcı kayıtlı değil. Kayıt işlemini başlatın.");
                registeredUsers.Add(username);
                Console.WriteLine("Kayıt başarılı! Devam edebilirsiniz.");
            }

            Console.WriteLine("Oy kullanmak istediğiniz kategori seçin:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            Console.WriteLine("Kategori numarasını girin:");
            int categoryIndex;
            if (int.TryParse(Console.ReadLine(), out categoryIndex) && categoryIndex > 0 && categoryIndex <= categories.Count)
            {
                string selectedCategory = categories[categoryIndex - 1];
                votes[selectedCategory]++;
                Console.WriteLine($"Oyunuz '{selectedCategory}' kategorisine eklendi.");
            }
            else
            {
                Console.WriteLine("Geçersiz kategori numarası. Lütfen tekrar deneyin.");
            }
        }

        DisplayResults();
    }

    static void DisplayResults()
    {
        Console.WriteLine("\nOylama sonuçları:");
        int totalVotes = votes.Values.Sum();
        
        if (totalVotes == 0)
        {
            Console.WriteLine("Henüz oy kullanılmadı.");
            return;
        }

        foreach (var category in categories)
        {
            int categoryVotes = votes[category];
            double percentage = (categoryVotes / (double)totalVotes) * 100;
            Console.WriteLine($"{category}: {categoryVotes} oy ({percentage:F2}%)");
        }
    }
}
