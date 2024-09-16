//InputHandler.cs
using System;

public class InputHandler
{
    public double GetCircleRadius()
    {
        double radius;
        while (true)
        {
            Console.Write("Dairenin yarıçapını girin: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out radius) && radius > 0)
            {
                return radius;
            }

            Console.WriteLine("Geçerli bir pozitif sayı girin.");
        }
    }
}

// CircleDrawer.cs
using System;

public class CircleDrawer
{
    public void DrawCircle(double radius)
    {
        int diameter = (int)(2 * radius);
        for (int y = 0; y <= diameter; y++)
        {
            for (int x = 0; x <= diameter; x++)
            {
                double distance = Math.Sqrt(Math.Pow(x - radius, 2) + Math.Pow(y - radius, 2));
                if (Math.Abs(distance - radius) < 0.5)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}

//Program.cs
using System;

class Program
{
    static void Main()
    {
        InputHandler inputHandler = new InputHandler();
        CircleDrawer circleDrawer = new CircleDrawer();

        double radius = inputHandler.GetCircleRadius();
        circleDrawer.DrawCircle(radius);
    }
}
