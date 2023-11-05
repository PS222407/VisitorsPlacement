namespace VisitorsPlacement_20_BusinessLogic.Models;

public class Visitor
{
    public string Email { get; private set; }

    private readonly DateTime _dateOfBirth;

    private Group? _group;

    public Chair? Chair { get; private set; }

    public int AgeInYears { get; private set; }

    public Visitor(string email, DateTime dateOfBirth, DateTime? eventStartDate = null)
    {
        Email = email;
        _dateOfBirth = dateOfBirth;

        if (eventStartDate != null)
        {
            SetAge(eventStartDate.Value);
        }
    }

    private int CalculateAgeInYears(DateTime dateToCompare)
    {
        int age = dateToCompare.Year - _dateOfBirth.Year;
        if (_dateOfBirth.AddYears(age) > dateToCompare)
        {
            age--;
        }

        return age;
    }
    
    public void SetAge(DateTime startDate)
    {
        AgeInYears = CalculateAgeInYears(startDate);
    }
    
    public bool IsAssignedToChair()
    {
        return Chair != null;
    }

    public bool IsAdult()
    {
        return AgeInYears > 12;
    }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Email) && _dateOfBirth < DateTime.Now;
    }

    public bool TryAssignChair(Chair chair)
    {
        if (chair.Visitor != null)
        {
            return false;
        }

        chair.AssignVisitor(this);
        Chair = chair;
        return true;
    }

    public void AssignGroup(Group group)
    {
        _group = group;
    }

    public override string ToString()
    {
        return $"Age: {CalculateAgeInYears(DateTime.Now)} - Group: {_group} - Email: {Email}";
    }
}