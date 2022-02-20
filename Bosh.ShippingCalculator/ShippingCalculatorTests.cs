using NUnit.Framework;

namespace Bosh.ShippingCalculator;

public class ShippingCalculatorTests
{
    [Test]
    public void GetPrice()
    {
        // Act
        var small = ShippingCalculator.GetPrice(6);
        var medium = ShippingCalculator.GetPrice(42);
        var large = ShippingCalculator.GetPrice(75);
        var xl = ShippingCalculator.GetPrice(101);

        // Assert
        Assert.AreEqual(3, small);
        Assert.AreEqual(8, medium);
        Assert.AreEqual(15, large);
        Assert.AreEqual(25, xl);
    }

    [Test]
    public void ExceptionTests()
    {
        // Act
        var exception = Assert.Throws<ArgumentException>(() => ShippingCalculator.GetPrice(-1));

        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Size must be greater than 0"));
    }
}