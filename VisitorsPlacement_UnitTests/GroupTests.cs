using VisitorsPlacement_20_BusinessLogic.Models;

namespace VisitorsPlacement_UnitTests;

public class GroupTests
{
    [Test]
    public void Group_validate_successfully()
    {
        // Arrange
        DateTime eventStartDate = DateTime.Parse("2023-06-10");
        List<Visitor> visitors = new()
        {
            new Visitor("lorem@email.email", DateTime.Parse("2000-11-14"), eventStartDate),
            new Visitor("ipsum@email.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@lorem.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@ipsum.email", DateTime.Parse("2020-08-20"), eventStartDate),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid();

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void Group_validate_only_children_fails()
    {
        // Arrange
        DateTime eventStartDate = DateTime.Parse("2023-06-10");
        List<Visitor> visitors = new()
        {
            new Visitor("email@email.email", DateTime.Parse("2021-11-14"), eventStartDate),
            new Visitor("email@email.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@email.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@email.email", DateTime.Parse("2020-08-20"), eventStartDate),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Group_validate_not_enough_adults_fails()
    {
        // Arrange
        DateTime eventStartDate = DateTime.Parse("2023-06-10");
        List<Visitor> visitors = new()
        {
            new Visitor("lorem@emailc.email", DateTime.Parse("2000-11-14"), eventStartDate),

            new Visitor("ipsum@email1.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@lorem2.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@ipsum3.email", DateTime.Parse("2020-08-20"), eventStartDate),
            new Visitor("ipsum@email4.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@lorem5.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@ipsum6.email", DateTime.Parse("2020-08-20"), eventStartDate),
            new Visitor("ipsum@email7.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@lorem8.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@ipsum9.email", DateTime.Parse("2020-08-20"), eventStartDate),
            new Visitor("ipsum@email0.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@lorema.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@ipsumb.email", DateTime.Parse("2020-08-20"), eventStartDate),
            new Visitor("email@ipsumt.email", DateTime.Parse("2020-08-20"), eventStartDate),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Group_validate_enough_adults_successfully()
    {
        // Arrange
        DateTime eventStartDate = DateTime.Parse("2023-06-10");
        List<Visitor> visitors = new()
        {
            new Visitor("lorem@emailc.email", DateTime.Parse("2000-11-14"), eventStartDate),
            new Visitor("loredm@emailc.email", DateTime.Parse("2000-11-14"), eventStartDate),

            new Visitor("ipsum@email1.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@lorem2.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@ipsum3.email", DateTime.Parse("2020-08-20"), eventStartDate),
            new Visitor("ipsum@email4.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@lorem5.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@ipsum6.email", DateTime.Parse("2020-08-20"), eventStartDate),
            new Visitor("ipsum@email7.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@lorem8.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@ipsum9.email", DateTime.Parse("2020-08-20"), eventStartDate),
            new Visitor("ipsum@email0.email", DateTime.Parse("2020-05-09"), eventStartDate),
            new Visitor("email@lorema.email", DateTime.Parse("2020-12-29"), eventStartDate),
            new Visitor("email@ipsumb.email", DateTime.Parse("2020-08-20"), eventStartDate),
            new Visitor("email@ipsumt.email", DateTime.Parse("2020-08-20"), eventStartDate),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid();

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void Group_validate_only_adults_successfully()
    {
        // Arrange
        DateTime eventStartDate = DateTime.Parse("2023-06-10");
        List<Visitor> visitors = new()
        {
            new Visitor("ipsum@email1.email", DateTime.Parse("2000-05-09"), eventStartDate),
            new Visitor("email@lorem2.email", DateTime.Parse("2000-12-29"), eventStartDate),
            new Visitor("email@ipsum3.email", DateTime.Parse("2000-08-20"), eventStartDate),
            new Visitor("ipsum@email4.email", DateTime.Parse("2000-05-09"), eventStartDate),
            new Visitor("email@lorem5.email", DateTime.Parse("2000-12-29"), eventStartDate),
            new Visitor("email@ipsum6.email", DateTime.Parse("2000-08-20"), eventStartDate),
            new Visitor("ipsum@email7.email", DateTime.Parse("2000-05-09"), eventStartDate),
            new Visitor("email@lorem8.email", DateTime.Parse("2000-12-29"), eventStartDate),
            new Visitor("email@ipsum9.email", DateTime.Parse("2000-08-20"), eventStartDate),
            new Visitor("ipsum@email0.email", DateTime.Parse("2000-05-09"), eventStartDate),
            new Visitor("email@lorema.email", DateTime.Parse("2000-12-29"), eventStartDate),
            new Visitor("email@ipsumb.email", DateTime.Parse("2000-08-20"), eventStartDate),
        };

        Group group = new(visitors);

        // Act
        bool result = group.IsValid();

        // Assert
        Assert.That(result, Is.True);
    }
}