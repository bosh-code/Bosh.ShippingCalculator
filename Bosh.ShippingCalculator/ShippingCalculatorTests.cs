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
        var heavyUnder50 = ShippingCalculator.PlaceOrder(101, false, 49.8);
        var heavyOver50 = ShippingCalculator.PlaceOrder(101, false, 52.8);
        var heavyOver50Speedy = ShippingCalculator.PlaceOrder(101, true, 52.8);

        // Assert
        Assert.AreEqual(3.0, small.Price);
        Assert.AreEqual(5.4, smallOverweight.Price);
        Assert.AreEqual(8.0, medium.Price);
        Assert.AreEqual(16.0, mediumSpeedy.Price);
        Assert.AreEqual(30.0, mediumSpeedyOverweight.Price);
        Assert.AreEqual(15.0, large.Price);
        Assert.AreEqual(25.0, xl.Price);
        Assert.AreEqual(75.0, heavyUnder50.Price);
        Assert.AreEqual(77.8, heavyOver50.Price);
        Assert.AreEqual(155.6, heavyOver50Speedy.Price);
    }

    [Test]
    public void ExceptionTests()
    {
        // Act
        var sizeArgumentException =
            Assert.Throws<ArgumentException>(() => ShippingCalculator.PlaceOrder(-1, false, 10));
        var sizeArgumentOutOfRangeException =
            Assert.Throws<ArgumentOutOfRangeException>(() => ShippingCalculator.PlaceOrder(Double.NaN, false, 10));
        var weightArgumentException =
            Assert.Throws<ArgumentException>(() => ShippingCalculator.PlaceOrder(.1, false, -1));

        // Assert
        Assert.That(sizeArgumentException?.Message, Is.EqualTo("Size must be greater than 0.00"));
        Assert.That(sizeArgumentOutOfRangeException?.Message,
            Is.EqualTo("Size must be valid (Parameter 'size')\nActual value was NaN."));
        Assert.That(weightArgumentException?.Message, Is.EqualTo("Weight must be greater than 0.00"));
    }
}