using VisitorsPlacement._20_BusinessLogic.Services;

namespace VisitorsPlacement.UnitTests;

public class SectionLetterHelperTests
{
    [Test]
    public void A_to_B_successfully()
    {
        // Arrange
        string sectionLetter = "A";
        
        // Act
        string result = SectionLetterHelper.GetNextAlphabet(sectionLetter);
        
        // Assert
        Assert.That(result, Is.EqualTo("B"));
    }
    
    [Test]
    public void L_to_M_successfully()
    {
        // Arrange
        string sectionLetter = "L";
        
        // Act
        string result = SectionLetterHelper.GetNextAlphabet(sectionLetter);
        
        // Assert
        Assert.That(result, Is.EqualTo("M"));
    }
    
    [Test]
    public void Z_to_AA_successfully()
    {
        // Arrange
        string sectionLetter = "Z";
        
        // Act
        string result = SectionLetterHelper.GetNextAlphabet(sectionLetter);
        
        // Assert
        Assert.That(result, Is.EqualTo("AA"));
    }
    
    [Test]
    public void LO_to_LP_successfully()
    {
        // Arrange
        string sectionLetter = "LO";
        
        // Act
        string result = SectionLetterHelper.GetNextAlphabet(sectionLetter);
        
        // Assert
        Assert.That(result, Is.EqualTo("LP"));
    }
}