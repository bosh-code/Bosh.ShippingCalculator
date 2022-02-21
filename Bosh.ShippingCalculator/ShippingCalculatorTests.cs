using NUnit.Framework;

namespace Bosh.ShippingCalculator;

public class ShippingCalculatorTests
{
    [Test]
    public void GetPrice()
    {
        // Act
        var small = ShippingCalculator.GetPrice(6, false);
        var medium = ShippingCalculator.GetPrice(42, false);
        var mediumSpeedy = ShippingCalculator.GetPrice(42, true);
        var large = ShippingCalculator.GetPrice(75, false);
        var xl = ShippingCalculator.GetPrice(101, false);

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
        var exception = Assert.Throws<ArgumentException>(() => ShippingCalculator.GetPrice(-1, false));

        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Size must be greater than 0"));
    }
}