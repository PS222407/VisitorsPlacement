using VisitorsPlacement._20_BusinessLogic.Models;

namespace VisitorsPlacement.UnitTests;

public class GroupTests
{
    [Test]
    public void Group_validate_successfully()
    {
        // Arrange
        List<Visitor> visitors = new()
        {
            new Visitor("lorem@email.email", DateTime.Parse("2000-11-14")),
            new Visitor("ipsum@email.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum.email", DateTime.Parse("2020-08-20")),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid(DateTime.Parse("2023-06-10"));

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void Group_validate_only_children_fails()
    {
        // Arrange
        List<Visitor> visitors = new()
        {
            new Visitor("email@email.email", DateTime.Parse("2021-11-14")),
            new Visitor("email@email.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@email.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@email.email", DateTime.Parse("2020-08-20")),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid(DateTime.Parse("2023-06-10"));

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Group_validate_not_enough_adults_fails()
    {
        // Arrange
        List<Visitor> visitors = new()
        {
            new Visitor("lorem@emailc.email", DateTime.Parse("2000-11-14")),

            new Visitor("ipsum@email1.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem2.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum3.email", DateTime.Parse("2020-08-20")),
            new Visitor("ipsum@email4.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem5.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum6.email", DateTime.Parse("2020-08-20")),
            new Visitor("ipsum@email7.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem8.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum9.email", DateTime.Parse("2020-08-20")),
            new Visitor("ipsum@email0.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorema.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsumb.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@ipsumt.email", DateTime.Parse("2020-08-20")),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid(DateTime.Parse("2023-06-10"));

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Group_validate_enough_adults_successfully()
    {
        // Arrange
        List<Visitor> visitors = new()
        {
            new Visitor("lorem@emailc.email", DateTime.Parse("2000-11-14")),
            new Visitor("loredm@emailc.email", DateTime.Parse("2000-11-14")),

            new Visitor("ipsum@email1.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem2.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum3.email", DateTime.Parse("2020-08-20")),
            new Visitor("ipsum@email4.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem5.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum6.email", DateTime.Parse("2020-08-20")),
            new Visitor("ipsum@email7.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem8.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum9.email", DateTime.Parse("2020-08-20")),
            new Visitor("ipsum@email0.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorema.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsumb.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@ipsumt.email", DateTime.Parse("2020-08-20")),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid(DateTime.Parse("2023-06-10"));

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void Group_validate_only_adults_successfully()
    {
        // Arrange
        List<Visitor> visitors = new()
        {
            new Visitor("ipsum@email1.email", DateTime.Parse("2000-05-09")),
            new Visitor("email@lorem2.email", DateTime.Parse("2000-12-29")),
            new Visitor("email@ipsum3.email", DateTime.Parse("2000-08-20")),
            new Visitor("ipsum@email4.email", DateTime.Parse("2000-05-09")),
            new Visitor("email@lorem5.email", DateTime.Parse("2000-12-29")),
            new Visitor("email@ipsum6.email", DateTime.Parse("2000-08-20")),
            new Visitor("ipsum@email7.email", DateTime.Parse("2000-05-09")),
            new Visitor("email@lorem8.email", DateTime.Parse("2000-12-29")),
            new Visitor("email@ipsum9.email", DateTime.Parse("2000-08-20")),
            new Visitor("ipsum@email0.email", DateTime.Parse("2000-05-09")),
            new Visitor("email@lorema.email", DateTime.Parse("2000-12-29")),
            new Visitor("email@ipsumb.email", DateTime.Parse("2000-08-20")),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid(DateTime.Parse("2023-06-10"));

        // Assert
        Assert.That(result, Is.True);
    }
}