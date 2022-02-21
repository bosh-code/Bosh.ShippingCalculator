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
        Overweight = calculateOverweight(size, weight);
        Price = CalculatePrice(size); // Price relies on weight
    }

    private bool calculateOverweight(double size, double weight)
    {
        if (size < 10 && weight > 1)
        {
            return true;
        }

        if (size < 50 && weight > 3)
        {
            return true;
        }

        if (size < 100 && weight > 6)
        {
            return true;
        }

        if (size >= 100 && weight > 10)
        {
            return true;
        }

        return false;
    }

    private static double CalculatePrice(double size)
    {
        return size switch
        {
            <= 0 => throw new ArgumentException("Size must be greater than 0.00"),
            < 10 => 3,
            < 50 => 8,
            < 100 => 15,
            >= 100 => 25
        };
    }
}