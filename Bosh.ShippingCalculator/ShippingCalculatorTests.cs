using NUnit.Framework;

namespace Bosh.ShippingCalculator;

public class ShippingCalculatorTests
{
    [Test]
    public void OrderTests()
    {
        // Act
        var small = ShippingCalculator.PlaceOrder(6, false, 0.7);
        var smallOverweight = ShippingCalculator.PlaceOrder(6, false, 1.2);
        var medium = ShippingCalculator.PlaceOrder(42, false, 2.9);
        var mediumSpeedy = ShippingCalculator.PlaceOrder(42, true, 2.8);
        var mediumSpeedyOverweight = ShippingCalculator.PlaceOrder(42, true, 3.5);
        var large = ShippingCalculator.PlaceOrder(75, false, 5.4);
        var xl = ShippingCalculator.PlaceOrder(101, false, 9.8);

        // Assert
        Assert.AreEqual(3, small.Price);
        Assert.AreEqual(5, smallOverweight.Price);
        Assert.AreEqual(8, medium.Price);
        Assert.AreEqual(16, mediumSpeedy.Price);
        Assert.AreEqual(20, mediumSpeedyOverweight.Price);
        Assert.AreEqual(15, large.Price);
        Assert.AreEqual(25, xl.Price);
    }

    [Test]
    public void ExceptionTests()
    {
        // Act
        var exception = Assert.Throws<ArgumentException>(() => ShippingCalculator.PlaceOrder(-1, false, -1));

        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Size must be greater than 0.00"));
    }
}