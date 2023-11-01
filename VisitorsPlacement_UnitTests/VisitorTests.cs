using VisitorsPlacement_20_BusinessLogic.Models;

namespace VisitorsPlacement_UnitTests;

public class VisitorTests
{
    [Test]
    public void Visitor_validate_successfully()
    {
        // Arrange
        Visitor visitor1 = new("lorem@email.email", DateTime.Parse("2000-11-14"));
        Visitor visitor2 = new("ipsum@email.email", DateTime.Parse("2001-11-14"));

        // Act
        bool result1 = visitor1.IsValid();
        bool result2 = visitor2.IsValid();

        // Assert
        Assert.That(result1 && result2, Is.True);
    }

    [Test]
    public void Visitor_validate_fails()
    {
        // Arrange
        Visitor visitor = new("", DateTime.Parse("2000-11-14"));

        // Act
        bool result = visitor.IsValid();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Visitor_is_adult_successfully()
    {
        // Arrange
        Visitor visitor = new("adult", DateTime.Parse("2000-01-01"));

        // Act
        bool result = visitor.IsAdult(DateTime.Parse("2013-01-01"));

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void Visitor_is_adult_fails()
    {
        // Arrange
        Visitor visitor = new("child", DateTime.Parse("2000-01-01"));

        // Act
        bool result = visitor.IsAdult(DateTime.Parse("2010-01-01"));

        // Assert
        Assert.That(result, Is.False);
    }
}