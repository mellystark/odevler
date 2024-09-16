// fibonacci service
public class FibonacciService
{
    public List<int> GenerateFibonacciSeries(int depth)
    {
        if (depth < 0)
        {
            throw new ArgumentException("Depth must be a non-negative integer.");
        }

        var series = new List<int>();

        if (depth == 0)
        {
            return series;
        }

        series.Add(0);

        if (depth == 1)
        {
            return series;
        }

        series.Add(1);

        for (int i = 2; i < depth; i++)
        {
            int nextValue = series[i - 1] + series[i - 2];
            series.Add(nextValue);
        }

        return series;
    }
}

// StatisticsService
public class StatisticsService
{
    public double CalculateAverage(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            throw new ArgumentException("The list of numbers cannot be null or empty.");
        }

        double sum = numbers.Sum();
        return sum / numbers.Count;
    }
}

// program
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the depth of Fibonacci series: ");
            int depth = int.Parse(Console.ReadLine());

            // Create instances of services
            var fibonacciService = new FibonacciService();
            var statisticsService = new StatisticsService();

            // Generate Fibonacci series
            List<int> fibonacciSeries = fibonacciService.GenerateFibonacciSeries(depth);

            // Calculate average
            double average = statisticsService.CalculateAverage(fibonacciSeries);

            // Display results
            Console.WriteLine($"Fibonacci series: {string.Join(", ", fibonacciSeries)}");
            Console.WriteLine($"Average of Fibonacci series: {average}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
