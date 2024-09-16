using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            // Kullanıcıdan giriş alın
            Console.Write("Giriş (string,index) formatında yapın veya 'çıkış' yazın: ");
            string input = Console.ReadLine();

            // Çıkış kontrolü
            if (input.ToLower() == "çıkış")
            {
                break;
            }

            // Girişi virgülle ayır
            string[] parts = input.Split(',');

            // Giriş kontrolü
            if (parts.Length != 2)
            {
                Console.WriteLine("Geçersiz giriş formatı. Lütfen 'string,index' formatında girin.");
                continue;
            }

            string str = parts[0];
            if (!int.TryParse(parts[1], out int index))
            {
                Console.WriteLine("Geçersiz indeks değeri.");
                continue;
            }

            // İndeks sınırlarını kontrol et
            if (index < 0 || index >= str.Length)
            {
                Console.WriteLine("İndeks, string uzunluğunun dışında.");
                continue;
            }

            // Belirtilen indeksteki karakteri çıkart
            string result = RemoveCharacterAtIndex(str, index);

            // Sonucu ekrana yazdır
            Console.WriteLine(result);
        }
    }

    // Belirtilen indeksteki karakteri çıkaran metod
    static string RemoveCharacterAtIndex(string str, int index)
    {
        return str.Remove(index, 1);
    }
}
