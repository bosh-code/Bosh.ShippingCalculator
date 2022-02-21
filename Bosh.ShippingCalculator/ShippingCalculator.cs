namespace Bosh.ShippingCalculator;

public static class ShippingCalculator
{
    
    public static Order PlaceOrder(int size, bool speedyShipping)
    {
        return new Order(size, speedyShipping);
    }
}