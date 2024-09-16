using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Lütfen sayıları girin (örneğin: 56 45 68 77):");
        string input = Console.ReadLine();

        // Giriş verilerini ayrıştır
        string[] tokens = input.Split(' ');
        List<int> numbers = new List<int>();

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Geçersiz sayı girişi: " + token);
                return;
            }
        }

        // Küçük ve büyük sayıları ayır
        var smallNumbers = numbers.Where(n => n < 67).ToList();
        var largeNumbers = numbers.Where(n => n > 67).ToList();

        int sumSmallDifferences = CalculateSmallNumbersSum(smallNumbers);
        int sumLargeSquares = CalculateLargeNumbersSum(largeNumbers);

        // Sonuçları ekrana yazdır
        Console.WriteLine($"{sumSmallDifferences} {sumLargeSquares}");
    }

    static int CalculateSmallNumbersSum(List<int> smallNumbers)
    {
        int sum = 0;
        for (int i = 0; i < smallNumbers.Count - 1; i++)
        {
            for (int j = i + 1; j < smallNumbers.Count; j++)
            {
                sum += Math.Abs(smallNumbers[i] - smallNumbers[j]);
            }
        }
        return sum;
    }

    static int CalculateLargeNumbersSum(List<int> largeNumbers)
    {
        int sum = 0;
        for (int i = 0; i < largeNumbers.Count - 1; i++)
        {
            for (int j = i + 1; j < largeNumbers.Count; j++)
            {
                int diff = Math.Abs(largeNumbers[i] - largeNumbers[j]);
                sum += diff * diff;
            }
        }
        return sum;
    }
}
