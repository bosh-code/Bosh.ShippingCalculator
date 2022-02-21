namespace Bosh.ShippingCalculator;

public class Order
{
    // The price field is set when the order is created.
    private readonly double _price;

    public double Price
    {
        // Getting the price returns the price * 2 if speedy shipping is applied
        get => SpeedyShipping ? Math.Round(_price * 2.0, 1, MidpointRounding.AwayFromZero) : _price;
        // Assume that the overweight charge is applied when the order is created.
        private init
        {
            _price = Overweight switch
            {
                true when Weight is > 10 and < 50 => Math.Round(value + 50.0, 1, MidpointRounding.AwayFromZero),
                true when Weight > 50 => Math.Round(value + 50.0 + Weight - 50.0, 1, MidpointRounding.AwayFromZero),
                true when Weight < 10 => Math.Round(value + Weight * 2.0, 1, MidpointRounding.AwayFromZero),
                _ => value
            };
        }
    }

    private bool SpeedyShipping { get; }
    private double Weight { get; }
    private bool Overweight { get; }

    public Order(double size, bool speedyShipping, double weight)
    {
        SpeedyShipping = speedyShipping;
        Weight = weight;
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