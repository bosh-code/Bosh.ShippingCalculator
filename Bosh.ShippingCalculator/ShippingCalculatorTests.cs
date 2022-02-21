using NUnit.Framework;

namespace Bosh.ShippingCalculator;

public class ShippingCalculatorTests
{
    [Test]
    public void OrderTests()
    {
        // Act
        var small = ShippingCalculator.PlaceOrder(6, false);
        var medium = ShippingCalculator.PlaceOrder(42, false);
        var mediumSpeedy = ShippingCalculator.PlaceOrder(42, true);
        var large = ShippingCalculator.PlaceOrder(75, false);
        var xl = ShippingCalculator.PlaceOrder(101, false);

        // Assert
        Assert.AreEqual(3, small.Price);
        Assert.AreEqual(8, medium.Price);
        Assert.AreEqual(16, mediumSpeedy.Price);
        Assert.AreEqual(15, large.Price);
        Assert.AreEqual(25, xl.Price);
    }

    [Test]
    public void ExceptionTests()
    {
        // Act
        var exception = Assert.Throws<ArgumentException>(() => ShippingCalculator.PlaceOrder(-1, false));

        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Size must be greater than 0"));
    }
}