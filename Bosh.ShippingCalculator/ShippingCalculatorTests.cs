using NUnit.Framework;

namespace Bosh.ShippingCalculator;

public class ShippingCalculatorTests
{
    [Test]
    public void GetPrice()
    {
        var result = ShippingCalculator.GetPrice(1);
        Assert.AreEqual(1, result);
    }
}
