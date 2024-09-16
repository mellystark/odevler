// InputHandler.cs
using System;

public class InputHandler
{
    public int GetTriangleSize()
    {
        int size;
        while (true)
        {
            Console.Write("Üçgenin yüksekliğini girin: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out size) && size > 0)
            {
                return size;
            }

            Console.WriteLine("Geçerli bir pozitif tamsayı girin.");
        }
    }
}

// TriangleDrawer.cs
using System;

public class TriangleDrawer
{
    public void DrawTriangle(int size)
    {
        for (int i = 1; i <= size; i++)
        {
            // Boşlukları yazdır
            for (int j = size - i; j > 0; j--)
            {
                Console.Write(" ");
            }

            // Yıldızları yazdır
            for (int k = 0; k < (2 * i - 1); k++)
            {
                Console.Write("*");
            }

            // Yeni satıra geç
            Console.WriteLine();
        }
    }
}

// Program.cs
using System;

class Program
{
    static void Main()
    {
        InputHandler inputHandler = new InputHandler();
        TriangleDrawer triangleDrawer = new TriangleDrawer();

        int size = inputHandler.GetTriangleSize();
        triangleDrawer.DrawTriangle(size);
    }
}
