namespace Bosh.ShippingCalculator;

public static class ShippingCalculator
{
    
    public static Order PlaceOrder(double size, bool speedyShipping, double weight)
    {
        return new Order(size, speedyShipping, weight);
    }
}