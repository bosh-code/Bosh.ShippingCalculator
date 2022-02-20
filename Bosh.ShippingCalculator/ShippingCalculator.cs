namespace Bosh.ShippingCalculator;

public static class ShippingCalculator
{
    public static int GetPrice(int size)
    {
        return size switch
        {
            < 10 => 3,
            < 50 => 8,
            < 100 => 15,
            >= 100 => 25
        };
    }
}