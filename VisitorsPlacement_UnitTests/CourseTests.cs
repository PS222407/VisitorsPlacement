using VisitorsPlacement_20_BusinessLogic.Models;

namespace VisitorsPlacement_UnitTests;

public class CourseTests
{
    public List<Section> Sections { get; set; }

    [SetUp]
    public void SetUp()
    {
        Sections = new List<Section>
        {
            new("A", 3, 3),
            new("B", 3, 2),
            new("C", 4, 3),
            new("D", 5, 1),
        };
    }

    [Test]
    public void Add_groups_with_unique_emails_successfully()
    {
        // Arrange
        Course course = new(DateTime.Now.AddDays(23), Sections);

        List<Visitor> visitors1 = new()
        {
            new Visitor("lorem@email.email", DateTime.Parse("2000-11-14")),
            new Visitor("ipsum@email.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum.email", DateTime.Parse("2020-08-20")),
        };
        Group group1 = new(visitors1);
        List<Visitor> visitors2 = new()
        {
            new Visitor("email@ipsum.1email", DateTime.Parse("2020-08-20")),
            new Visitor("email@lorem.1email", DateTime.Parse("2020-12-29")),
            new Visitor("ipsum@email.1email", DateTime.Parse("2020-05-09")),
            new Visitor("lorem@email.1email", DateTime.Parse("2000-11-14")),
        };
        Group group2 = new(visitors2);

        // Act
        bool result1 = course.TryAddGroup(group1);
        bool result2 = course.TryAddGroup(group2);

        // Assert
        Assert.That(result1 && result2, Is.True);
    }

    [Test]
    public void Add_groups_with_non_unique_emails_fails()
    {
        // Arrange
        Course course = new(DateTime.Now.AddDays(23), Sections);

        List<Visitor> visitors1 = new()
        {
            new Visitor("lorem@email.email", DateTime.Parse("2000-11-14")),
            new Visitor("ipsum@email.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum.email", DateTime.Parse("2020-08-20")),
        };
        Group group1 = new(visitors1);
        List<Visitor> visitors2 = new()
        {
            new Visitor("email@ipsum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@lorem.email", DateTime.Parse("2020-12-29")),
            new Visitor("ipsum@email.email", DateTime.Parse("2020-05-09")),
            new Visitor("lorem@email.email", DateTime.Parse("2000-11-14")),
        };
        Group group2 = new(visitors2);

        // Act
        bool result1 = course.TryAddGroup(group1);
        bool result2 = course.TryAddGroup(group2);

        // Assert
        Assert.That(result1 && result2, Is.False);
    }

    [Test]
    public void Add_group_too_late_fails()
    {
        // Arrange
        Course course = new(DateTime.Parse("2020-01-01"), Sections);
        Group group = new(new Visitor("lorem@email.email", DateTime.Parse("2000-11-14")));

        // Act
        bool result = course.TryAddGroup(group);

        // Assert
        Assert.That(result, Is.False);
    }
}