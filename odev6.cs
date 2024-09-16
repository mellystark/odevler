using System;

public interface IGeometricShape
{
    double Calculate(string calculationType);
}

public class Circle : IGeometricShape
{
    public double Radius { get; set; }

    public double Calculate(string calculationType)
    {
        switch (calculationType.ToLower())
        {
            case "alan":
                return Math.PI * Radius * Radius;
            case "çevre":
                return 2 * Math.PI * Radius;
            default:
                throw new ArgumentException("Geçersiz hesaplama türü");
        }
    }
}

public class Rectangle : IGeometricShape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public double Calculate(string calculationType)
    {
        switch (calculationType.ToLower())
        {
            case "alan":
                return Length * Width;
            case "çevre":
                return 2 * (Length + Width);
            default:
                throw new ArgumentException("Geçersiz hesaplama türü");
        }
    }
}

public class Square : IGeometricShape
{
    public double Side { get; set; }

    public double Calculate(string calculationType)
    {
        switch (calculationType.ToLower())
        {
            case "alan":
                return Side * Side;
            case "çevre":
                return 4 * Side;
            default:
                throw new ArgumentException("Geçersiz hesaplama türü");
        }
    }
}

public class Triangle : IGeometricShape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public double Calculate(string calculationType)
    {
        switch (calculationType.ToLower())
        {
            case "alan":
                // Heron'un formülü ile alan hesaplama
                double s = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
            case "çevre":
                return SideA + SideB + SideC;
            default:
                throw new ArgumentException("Geçersiz hesaplama türü");
        }
    }
}
