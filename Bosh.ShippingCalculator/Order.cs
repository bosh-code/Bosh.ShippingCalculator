namespace Bosh.ShippingCalculator;

public class Order
{
    // The price field is set when the order is created.
    private readonly int _price;

    public int Price
    {
        // Getting the price returns the price * 2 if speedy shipping is applied
        get => SpeedyShipping ? _price * 2 : _price;
        private init => _price = value;
    }

    private bool SpeedyShipping { get; }

    public Order(int size, bool speedyShipping)
    {
        Price = CalculatePrice(size);
        SpeedyShipping = speedyShipping;
    }

    private static int CalculatePrice(int size)
    {
        return size switch
        {
            <= 0 => throw new ArgumentException("Size must be greater than 0"),
            < 10 => 3,
            < 50 => 8,
            < 100 => 15,
            >= 100 => 25
        };
    }
}