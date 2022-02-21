namespace Bosh.ShippingCalculator;

public class Order
{
    public bool SpeedyShipping { get; set; }
    public int Price { get; set; }
    public int PriceWithShipping { get; set; }

    public Order(int size, bool speedyShipping)
    {
        Price = CalculatePrice(size);
        SpeedyShipping = speedyShipping;
        PriceWithShipping = SpeedyShipping ? Price * 2 : Price;
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