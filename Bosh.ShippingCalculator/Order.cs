namespace Bosh.ShippingCalculator;

public class Order
{
    // The price field is set when the order is created.
    private readonly double _price;

    public double Price
    {
        // Getting the price returns the price * 2 if speedy shipping is applied
        get => SpeedyShipping ? _price * 2.0 : _price;
        private init => _price = Overweight ? value + 2.0 : value;
    }

    private bool SpeedyShipping { get; }
    private bool Overweight { get; }

    public Order(double size, bool speedyShipping, double weight)
    {
        SpeedyShipping = speedyShipping;
        Overweight = CalculateOverweight(size, weight);
        Price = CalculatePrice(size); // Price relies on weight
    }

    private static bool CalculateOverweight(double size, double weight)
    {
        return size switch
        {
            < 1 when weight <= 0 => throw new ArgumentException("Weight must be greater than 0.00"),
            < 10 when weight > 1 => true,
            < 50 when weight > 3 => true,
            < 100 when weight > 6 => true,
            >= 100 when weight > 10 => true,
            _ => false // Also catches NaN / Errors
        };
    }

    private static double CalculatePrice(double size)
    {
        return size switch
        {
            <= 0 => throw new ArgumentException("Size must be greater than 0.00"),
            < 10 => 3,
            < 50 => 8,
            < 100 => 15,
            >= 100 => 25,
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, "Size must be valid")
        };
    }
}