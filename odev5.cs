using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Birden fazla kelime girin (boşluk ile ayırın):");
        string input = Console.ReadLine();
        
        // Girişi boşluklara göre ayır
        string[] words = input.Split(' ');

        foreach (string word in words)
        {
            // Her kelime için karakterleri yer değiştir
            string result = SwapCharacters(word);
            Console.Write(result + " ");
        }
    }

    // Karakterleri bir önceki karakter ile yer değiştiren metod
    static string SwapCharacters(string str)
    {
        char[] characters = str.ToCharArray();

        // Karakterleri bir önceki karakter ile yer değiştir
        for (int i = 1; i < characters.Length; i++)
        {
            // Karakterleri takas et
            char temp = characters[i];
            characters[i] = characters[i - 1];
            characters[i - 1] = temp;
        }

        return new string(characters);
    }
}
