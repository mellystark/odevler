using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Lütfen string ifadeyi girin (örneğin: Merhaba Umut Arya):");
        string input = Console.ReadLine();

        // Sessiz harfler
        string consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
        
        // Giriş verilerini ayrıştır
        string[] words = input.Split(' ');

        // Her kelime için yanyana iki sessiz harf olup olmadığını kontrol et
        foreach (var word in words)
        {
            bool hasConsecutiveConsonants = CheckConsecutiveConsonants(word, consonants);
            Console.Write(hasConsecutiveConsonants ? "True " : "False ");
        }
    }

    static bool CheckConsecutiveConsonants(string word, string consonants)
    {
        for (int i = 0; i < word.Length - 1; i++)
        {
            if (consonants.Contains(word[i]) && consonants.Contains(word[i + 1]))
            {
                return true;
            }
        }
        return false;
    }
}
