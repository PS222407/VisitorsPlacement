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

    [Test]
    public void Calculate_visitor_placements_successfully()
    {
        // Arrange
        Course course = new(DateTime.Now.AddDays(23), Sections);

        List<Visitor> visitors1 = new()
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
        Group group1 = new(visitors1);

        List<Visitor> visitors2 = new()
        {
            new Visitor("lorem@email.email", DateTime.Parse("2000-11-14")),
            new Visitor("ipsum@email.email", DateTime.Parse("2020-05-09")),
            new Visitor("email@lorem.email", DateTime.Parse("2020-12-29")),
            new Visitor("email@ipsum.email", DateTime.Parse("2020-08-20")),
        };
        Group group2 = new(visitors2);

        List<Visitor> visitors3 = new()
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
        Group group3 = new(visitors3);

        Group group4 = new(new Visitor("jklfsd@jkfsld.lksfdj", DateTime.Parse("2000-11-14")));

        List<Visitor> visitors5 = new()
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
        Group group5 = new(visitors5);

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

        List<Visitor> visitors7 = new()
        {
            new Visitor("lorem@e131mail.email", DateTime.Parse("2000-11-14")),
            new Visitor("lorem@e141mail.email", DateTime.Parse("2000-11-14")),

            new Visitor("email@i191p1sum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i101p2sum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i111p3sum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i131p4sum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i131p5sum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i191p6sum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i101p7sum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i111p8sum.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i131p9sum.email", DateTime.Parse("2020-08-20")),

            new Visitor("email@i191ps4411um.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i101ps44u12m.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i111ps44u13m.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i131ps44u14m.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i131ps44u15m.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i191ps44u16m.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i101ps44u17m.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i111ps44u18m.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i1324231psum.email", DateTime.Parse("2020-08-20")),

            new Visitor("lorem@e151mail.email", DateTime.Parse("2000-11-14")),

            new Visitor("email@i131ps444454um.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i191p44456s4um.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i101ps435634um.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i111ps224666um.email", DateTime.Parse("2020-08-20")),
            new Visitor("email@i131ps345553um.email", DateTime.Parse("2020-08-20")),

            new Visitor("ipsum@e161mail.email", DateTime.Parse("2000-05-09")),
        };
        Group group7 = new(visitors7);

        course.TryAddGroup(group1);
        course.TryAddGroup(group2);
        course.TryAddGroup(group3);
        course.TryAddGroup(group4);
        course.TryAddGroup(group5);
        course.TryAddGroup(group6);
        course.TryAddGroup(group7);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
    }
}