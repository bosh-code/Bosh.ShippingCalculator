namespace Bosh.ShippingCalculator;

public static class ShippingCalculator
{
    /// <summary>
    /// Driver method to create Orders
    /// </summary>
    /// <param name="size">(Double) The size of the order</param>
    /// <param name="speedyShipping">(Boolean) Whether to add the speedy shipping charge</param>
    /// <param name="weight">(Double) The weight of the order</param>
    /// <returns>A new order</returns>
    public static Order PlaceOrder(double size, bool speedyShipping, double weight)
    {
        return new Order(size, speedyShipping, weight);
    }
}