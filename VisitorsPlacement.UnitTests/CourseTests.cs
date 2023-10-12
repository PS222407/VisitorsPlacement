using VisitorsPlacement._20_BusinessLogic.Models;

namespace VisitorsPlacement.UnitTests;

public class CourseTests
{
    [Test]
    public void Add_groups_with_unique_emails_successfully()
    {
        // Arrange
        Course course = new(DateTime.Now.AddDays(23));

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
        Course course = new(DateTime.Now.AddDays(23));

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
        Course course = new(DateTime.Parse("2020-01-01"));
        Group group = new(new Visitor("lorem@email.email", DateTime.Parse("2000-11-14")));

        // Act
        bool result = course.TryAddGroup(group);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Calculate_visitor_placements_successfully()
    {
        // Arrange
        Course course = new(DateTime.Now.AddDays(23));

        List<Visitor> visitors5 = new()
        {
            new Visitor("lorem@e13mail.1email", DateTime.Parse("2000-11-14")),
            new Visitor("lorem@e14mail.1email", DateTime.Parse("2000-11-14")),
            new Visitor("lorem@e15mail.1email", DateTime.Parse("2000-11-14")),
            new Visitor("ipsum@e16mail.1email", DateTime.Parse("2000-05-09")),
            new Visitor("email@l17orem.1email", DateTime.Parse("2000-12-29")),
            new Visitor("email@i18psum.1email", DateTime.Parse("2000-08-20")),
            new Visitor("email@i19psum.1email", DateTime.Parse("2000-08-20")),
            new Visitor("email@i10psum.1email", DateTime.Parse("2000-08-20")),
            new Visitor("email@i11psum.1email", DateTime.Parse("2000-08-20")),
            new Visitor("email@i13psum.1email", DateTime.Parse("2000-08-20")),
        };
        Group group5 = new(visitors5);
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
            new Visitor("lore1m@email.email", DateTime.Parse("2000-11-14")),
            new Visitor("lore2m@email.email", DateTime.Parse("2000-11-14")),
            new Visitor("lore3m@email.email", DateTime.Parse("2000-11-14")),
            new Visitor("ipsu4m@email.email", DateTime.Parse("2020-05-09")),
            new Visitor("emai5l@lorem.email", DateTime.Parse("2020-12-29")),
            new Visitor("emai6l@ipsum.email", DateTime.Parse("2020-08-20")),
            new Visitor("emai7l@ipsum.email", DateTime.Parse("2020-08-20")),
            new Visitor("emai9l@ipsum.email", DateTime.Parse("2020-08-20")),
            new Visitor("emai0l@ipsum.email", DateTime.Parse("2020-08-20")),
        };
        Group group2 = new(visitors2);
        Group group3 = new(new Visitor("jklfsd@jkfsld.lksfdj", DateTime.Parse("2000-11-14")));
        List<Visitor> visitors4 = new()
        {
            new Visitor("lorem@e13mail.email", DateTime.Parse("2000-11-14")),
            new Visitor("lorem@e14mail.email", DateTime.Parse("2000-11-14")),
            new Visitor("lorem@e15mail.email", DateTime.Parse("2000-11-14")),
            new Visitor("ipsum@e16mail.email", DateTime.Parse("2000-05-09")),
            new Visitor("email@l17orem.email", DateTime.Parse("2000-12-29")),
            new Visitor("email@i18psum.email", DateTime.Parse("2000-08-20")),
            new Visitor("email@i19psum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i10psum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i11psum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i13psum.email", DateTime.Parse("2020-08-20")),
        };
        Group group4 = new(visitors4);
        List<Visitor> visitors6 = new()
        {
            new Visitor("lorem@e13mail.email", DateTime.Parse("2000-11-14")),
            new Visitor("lorem@e14mail.email", DateTime.Parse("2000-11-14")),
            new Visitor("lorem@e15mail.email", DateTime.Parse("2000-11-14")),
            new Visitor("ipsum@e16mail.email", DateTime.Parse("2000-05-09")),
            new Visitor("email@l17orem.email", DateTime.Parse("2000-12-29")),
            new Visitor("email@i18psum.email", DateTime.Parse("2000-08-20")),
            new Visitor("email@i19psum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i10psum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i11psum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i13psum.email", DateTime.Parse("2020-08-20")),
        };
        Group group6 = new(visitors6);

        course.TryAddGroup(group1);
        course.TryAddGroup(group2);
        course.TryAddGroup(group3);
        course.TryAddGroup(group4);
        course.TryAddGroup(group5);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
    }
}