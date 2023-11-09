using VisitorsPlacement_20_BusinessLogic.Models;

namespace VisitorsPlacement_UnitTests;

public class PlacementTests
{
    [Test]
    public void TestCase_1()
    {
        // Arrange
        List<Section> sections = new()
        {
            new Section("A", 4, 2),
            new Section("B", 4, 1),
        };
        Course course = new(DateTime.Parse("2023-06-10"), sections);

        Group group1 = new(new List<Visitor>
        {
            new("1test@test.test", DateTime.Parse("2000-01-01")),
            new("2test@test.test", DateTime.Parse("2020-01-01")),
        }, 1);
        Group group2 = new(new List<Visitor>
        {
            new("1test@test.test", DateTime.Parse("2000-01-01")),
            new("2test@test.test", DateTime.Parse("2020-01-01")),
            new("3test@test.test", DateTime.Parse("2020-01-01")),
        }, 2);

        course.TryAddGroup(group1);
        course.TryAddGroup(group2);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
        string result1 = "1C 1A XX XX \n " +
                         "XX XX XX XX";

        string result2 = "2C 2C 2A XX";

        var a = sections[0].DisplayInAscii();
        var b = sections[1].DisplayInAscii();
        Assert.Multiple(() =>
        {
            Assert.That(a, Is.EqualTo(result1));
            Assert.That(b, Is.EqualTo(result2));
        });
    }
}