using System;
using System.Drawing; // Bitmap kullanımı için
using System.Drawing.Imaging; // Image formatı için
using System.IO; // Dosya işlemleri için
using ZXing; // ZXing kütüphanesi

class Program
{
    static void Main()
    {
        Console.WriteLine("Barkod Oluşturma ve Okuma Uygulaması");

        // Barkod oluşturma
        Console.WriteLine("Barkod oluşturmak için bir metin girin:");
        string textToEncode = Console.ReadLine();
        string barcodeFilePath = "barcode.png";
        GenerateBarcode(textToEncode, barcodeFilePath);
        Console.WriteLine($"Barkod '{barcodeFilePath}' dosyasına kaydedildi.");

        // Barkod okuma
        Console.WriteLine("Barkod dosyasını okumak için dosya adını girin:");
        string fileToRead = Console.ReadLine();
        string decodedText = DecodeBarcode(fileToRead);
        if (decodedText != null)
        {
            Console.WriteLine($"Barkod içeriği: {decodedText}");
        }
        else
        {
            Console.WriteLine("Barkod okunamadı.");
        }
    }

    static void GenerateBarcode(string text, string filePath)
    {
        BarcodeWriter barcodeWriter = new BarcodeWriter
        {
            Encoding = System.Text.Encoding.UTF8,
            Format = BarcodeFormat.CODE_128, // Barkod formatı
            Options = new ZXing.Common.EncodingOptions
            {
                Width = 300,
                Height = 150
            }
        };

        using (Bitmap bitmap = barcodeWriter.Write(text))
        {
            bitmap.Save(filePath, ImageFormat.Png);
        }
    }

    static string DecodeBarcode(string filePath)
    {
        BarcodeReader barcodeReader = new BarcodeReader();
        using (Bitmap bitmap = new Bitmap(filePath))
        {
            var result = barcodeReader.Decode(bitmap);
            return result?.Text;
        }
    }
}
