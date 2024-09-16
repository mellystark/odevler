using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Lütfen sayıları girin (örneğin: 2 3 1 5 2 5 3 3):");
        string input = Console.ReadLine();

        // Giriş verilerini ayrıştır
        string[] tokens = input.Split(' ');
        if (tokens.Length % 2 != 0)
        {
            Console.WriteLine("Hatalı giriş. Çift sayıda sayı girilmelidir.");
            return;
        }

        List<int> results = new List<int>();

        for (int i = 0; i < tokens.Length; i += 2)
        {
            int number1 = int.Parse(tokens[i]);
            int number2 = int.Parse(tokens[i + 1]);

            int sum = number1 + number2;

            if (number1 == number2)
            {
                results.Add(sum * sum); // Aynıysa toplamının karesi
            }
            else
            {
                results.Add(sum); // Farklıysa toplam
            }
        }

        // Sonuçları ekrana yazdır
        Console.WriteLine(string.Join(" ", results));
    }
}
