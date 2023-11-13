using VisitorsPlacement_20_BusinessLogic.Models;

namespace VisitorsPlacement_UnitTests;

public class PlacementTests
{
    // =======================================================
    // !!!!!!!!!!!!!!!! IMPORTANT !!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // =======================================================
    // These testcases are visualized in PDF format in the root
    // directory of this project.
    
    [Test]
    public void TestCase_1()
    {
        // Arrange
        List<Section> sections = new()
        {
            new Section("A", 4, 2),
            new Section("B", 4, 1),
        };
        Course course = new(DateTime.Parse("2123-06-10"), sections);

        Group group1 = new(new List<Visitor>
        {
            new("test1@test.test", DateTime.Parse("2100-01-01")),

            new("test2@test.test", DateTime.Parse("2120-01-01")),
        }, 1);
        Group group2 = new(new List<Visitor>
        {
            new("test3@test.test", DateTime.Parse("2100-01-01")),

            new("test4@test.test", DateTime.Parse("2120-01-01")),
            new("test5@test.test", DateTime.Parse("2120-01-01")),
        }, 2);

        group1.RegistrationDate = DateTime.Parse("2123-01-01");
        course.TryAddGroup(group1);
        group2.RegistrationDate = DateTime.Parse("2123-01-02");
        course.TryAddGroup(group2);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
        string result1ToCompare = "1C 1A XX XX \n " +
                                  "XX XX XX XX \n ";

        string result2ToCompare = "2C 2C 2A XX \n ";

        string result1 = sections[0].DisplayInAscii();
        string result2 = sections[1].DisplayInAscii();
        Assert.Multiple(() =>
        {
            Assert.That(result1ToCompare, Is.EqualTo(result1));
            Assert.That(result2ToCompare, Is.EqualTo(result2));
        });
    }

    [Test]
    public void TestCase_2()
    {
        // Arrange
        List<Section> sections = new()
        {
            new Section("A", 4, 2),
            new Section("B", 4, 1),
        };
        Course course = new(DateTime.Parse("2123-06-10"), sections);

        Group group1 = new(new List<Visitor>
        {
            new("test1@test.test", DateTime.Parse("2100-01-01")),

            new("test2@test.test", DateTime.Parse("2120-01-01")),
        }, 1);
        Group group2 = new(new List<Visitor>
        {
            new("test3@test.test", DateTime.Parse("2100-01-01")),

            new("test4@test.test", DateTime.Parse("2120-01-01")),
        }, 2);

        group1.RegistrationDate = DateTime.Parse("2123-01-01");
        course.TryAddGroup(group1);
        group2.RegistrationDate = DateTime.Parse("2123-01-02");
        course.TryAddGroup(group2);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
        string result1ToCompare = "1C 1A 2C 2A \n " +
                                  "XX XX XX XX \n ";

        string result2ToCompare = "XX XX XX XX \n ";

        string result1 = sections[0].DisplayInAscii();
        string result2 = sections[1].DisplayInAscii();
        Assert.Multiple(() =>
        {
            Assert.That(result1ToCompare, Is.EqualTo(result1));
            Assert.That(result2ToCompare, Is.EqualTo(result2));
        });
    }

    [Test]
    public void TestCase_3()
    {
        // Arrange
        List<Section> sections = new()
        {
            new Section("A", 4, 2),
            new Section("B", 4, 1),
        };
        Course course = new(DateTime.Parse("2123-06-10"), sections);

        Group group1 = new(new List<Visitor>
        {
            new("test1@test.test", DateTime.Parse("2100-01-01")),

            new("test2@test.test", DateTime.Parse("2120-01-01")),
        }, 1);
        Group group2 = new(new List<Visitor>
        {
            new("test3@test.test", DateTime.Parse("2100-01-01")),
            new("test4@test.test", DateTime.Parse("2100-01-01")),

            new("test5@test.test", DateTime.Parse("2120-01-01")),
            new("test6@test.test", DateTime.Parse("2120-01-01")),
        }, 2);

        group1.RegistrationDate = DateTime.Parse("2123-01-01");
        course.TryAddGroup(group1);
        group2.RegistrationDate = DateTime.Parse("2123-01-02");
        course.TryAddGroup(group2);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
        string result1ToCompare = "1C 1A XX XX \n " +
                                  "XX XX XX XX \n ";

        string result2ToCompare = "2C 2C 2A 2A \n ";

        string result1 = sections[0].DisplayInAscii();
        string result2 = sections[1].DisplayInAscii();
        Assert.Multiple(() =>
        {
            Assert.That(result1ToCompare, Is.EqualTo(result1));
            Assert.That(result2ToCompare, Is.EqualTo(result2));
        });
    }

    [Test]
    public void TestCase_4()
    {
        // Arrange
        List<Section> sections = new()
        {
            new Section("A", 4, 2),
            new Section("B", 4, 1),
        };
        Course course = new(DateTime.Parse("2123-06-10"), sections);

        Group group1 = new(new List<Visitor>
        {
            new("test1@test.test", DateTime.Parse("2100-01-01")),

            new("test2@test.test", DateTime.Parse("2120-01-01")),
        }, 1);
        Group group2 = new(new List<Visitor>
        {
            new("test3@test.test", DateTime.Parse("2100-01-01")),
            new("test4@test.test", DateTime.Parse("2100-01-01")),
            new("test5@test.test", DateTime.Parse("2100-01-01")),
            new("test6@test.test", DateTime.Parse("2100-01-01")),
            new("test7@test.test", DateTime.Parse("2100-01-01")),

            new("test8@test.test", DateTime.Parse("2120-01-01")),
            new("test9@test.test", DateTime.Parse("2120-01-01")),
        }, 2);

        group1.RegistrationDate = DateTime.Parse("2123-01-01");
        course.TryAddGroup(group1);
        group2.RegistrationDate = DateTime.Parse("2123-01-02");
        course.TryAddGroup(group2);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
        string result1ToCompare = "1C 1A XX XX \n " +
                                  "XX XX XX XX \n ";

        string result2ToCompare = "2C 2C 2A 2A \n ";

        string result1 = sections[0].DisplayInAscii();
        string result2 = sections[1].DisplayInAscii();
        Assert.Multiple(() =>
        {
            Assert.That(result1ToCompare, Is.EqualTo(result1));
            Assert.That(result2ToCompare, Is.EqualTo(result2));
        });
    }

    [Test]
    public void TestCase_5()
    {
        // Arrange
        List<Section> sections = new()
        {
            new Section("A", 4, 2),
            new Section("B", 4, 1),
        };
        Course course = new(DateTime.Parse("2123-06-10"), sections);

        Group group1 = new(new List<Visitor>
        {
            new("test1@test.test", DateTime.Parse("2100-01-01")),
            new("test2@test.test", DateTime.Parse("2100-01-01")),
            new("test3@test.test", DateTime.Parse("2100-01-01")),
            new("test4@test.test", DateTime.Parse("2100-01-01")),
            new("test5@test.test", DateTime.Parse("2100-01-01")),
        }, 1);
        Group group2 = new(new List<Visitor>
        {
            new("test6@test.test", DateTime.Parse("2100-01-01")),

            new("test7@test.test", DateTime.Parse("2120-01-01")),
            new("test8@test.test", DateTime.Parse("2120-01-01")),
        }, 2);
        Group group3 = new(new List<Visitor>
        {
            new("test9@test.test", DateTime.Parse("2100-01-01")),

            new("test10@test.test", DateTime.Parse("2120-01-01")),
            new("test11@test.test", DateTime.Parse("2120-01-01")),
            new("test12@test.test", DateTime.Parse("2120-01-01")),
        }, 3);

        group1.RegistrationDate = DateTime.Parse("2123-01-01");
        course.TryAddGroup(group1);
        group2.RegistrationDate = DateTime.Parse("2123-01-02");
        course.TryAddGroup(group2);
        group3.RegistrationDate = DateTime.Parse("2123-01-03");
        course.TryAddGroup(group3);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
        string result1ToCompare = "2C 2C 2A 1A \n " +
                                  "1A 1A 1A 1A \n ";

        string result2ToCompare = "3C 3C 3C 3A \n ";

        string result1 = sections[0].DisplayInAscii();
        string result2 = sections[1].DisplayInAscii();
        Assert.Multiple(() =>
        {
            Assert.That(result1ToCompare, Is.EqualTo(result1));
            Assert.That(result2ToCompare, Is.EqualTo(result2));
        });
    }

    [Test]
    public void TestCase_6()
    {
        // Arrange
        List<Section> sections = new()
        {
            new Section("A", 4, 2),
            new Section("B", 4, 1),
        };
        Course course = new(DateTime.Parse("2123-06-10"), sections);

        Group group1 = new(new List<Visitor>
        {
            new("test1@test.test", DateTime.Parse("2100-01-01")),
            new("test2@test.test", DateTime.Parse("2100-01-01")),
            new("test3@test.test", DateTime.Parse("2100-01-01")),
            new("test4@test.test", DateTime.Parse("2100-01-01")),
            new("test5@test.test", DateTime.Parse("2100-01-01")),
            new("test6@test.test", DateTime.Parse("2100-01-01")),
        }, 1);
        Group group2 = new(new List<Visitor>
        {
            new("test7@test.test", DateTime.Parse("2100-01-01")),

            new("test8@test.test", DateTime.Parse("2120-01-01")),
            new("test9@test.test", DateTime.Parse("2120-01-01")),
        }, 2);
        Group group3 = new(new List<Visitor>
        {
            new("test10@test.test", DateTime.Parse("2100-01-01")),

            new("test11@test.test", DateTime.Parse("2120-01-01")),
            new("test12@test.test", DateTime.Parse("2120-01-01")),
            new("test13@test.test", DateTime.Parse("2120-01-01")),
        }, 3);

        group1.RegistrationDate = DateTime.Parse("2123-01-01");
        course.TryAddGroup(group1);
        group2.RegistrationDate = DateTime.Parse("2123-01-02");
        course.TryAddGroup(group2);
        group3.RegistrationDate = DateTime.Parse("2123-01-03");
        course.TryAddGroup(group3);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
        string result1ToCompare = "1A 1A 1A 1A \n " +
                                  "1A 1A XX XX \n ";

        string result2ToCompare = "2C 2C 2A XX \n ";

        string result1 = sections[0].DisplayInAscii();
        string result2 = sections[1].DisplayInAscii();
        Assert.Multiple(() =>
        {
            Assert.That(result1ToCompare, Is.EqualTo(result1));
            Assert.That(result2ToCompare, Is.EqualTo(result2));
        });
    }

    [Test]
    public void TestCase_7()
    {
        // Arrange
        List<Section> sections = new()
        {
            new Section("A", 7, 2),
        };
        Course course = new(DateTime.Parse("2123-06-10"), sections);

        Group group1 = new(new List<Visitor>
        {
            new("test1@test.test", DateTime.Parse("2100-01-01")),
            new("test2@test.test", DateTime.Parse("2100-01-01")),
            new("test3@test.test", DateTime.Parse("2100-01-01")),

            new("test4@test.test", DateTime.Parse("2120-01-01")),
            new("test5@test.test", DateTime.Parse("2120-01-01")),
            new("test6@test.test", DateTime.Parse("2120-01-01")),
        }, 1);
        Group group2 = new(new List<Visitor>
        {
            new("test7@test.test", DateTime.Parse("2100-01-01")),
            new("test8@test.test", DateTime.Parse("2100-01-01")),
            new("test9@test.test", DateTime.Parse("2100-01-01")),

            new("test10@test.test", DateTime.Parse("2120-01-01")),
            new("test11@test.test", DateTime.Parse("2120-01-01")),
        }, 2);

        group1.RegistrationDate = DateTime.Parse("2123-01-01");
        course.TryAddGroup(group1);
        group2.RegistrationDate = DateTime.Parse("2123-01-02");
        course.TryAddGroup(group2);

        // Act
        course.CalculateVisitorPlacements();

        // Assert
        string result1ToCompare = "1C 1C 1C 1A 2C 2C 2A \n " +
                                  "1A 1A 2A 2A XX XX XX \n ";

        string result1 = sections[0].DisplayInAscii();
        Assert.Multiple(() => { Assert.That(result1ToCompare, Is.EqualTo(result1)); });
    }
}