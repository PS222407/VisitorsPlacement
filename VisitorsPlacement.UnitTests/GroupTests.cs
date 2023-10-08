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
    public void Group_validate_fails()
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
}