namespace Bosh.ShippingCalculator;

public static class ShippingCalculator
{
    public static int GetPrice(int size, bool speedyShipping)
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