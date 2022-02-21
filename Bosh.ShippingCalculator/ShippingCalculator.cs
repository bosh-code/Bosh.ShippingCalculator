namespace Bosh.ShippingCalculator;

public static class ShippingCalculator
{
    public static Order GetPrice(int size, bool speedyShipping)
    {
        return new Order(size, speedyShipping);
    }
}