namespace VisitorsPlacement_20_BusinessLogic.Models;

public class Visitor
{
    public string Email { get; }

    private readonly DateTime _dateOfBirth;

    private Group? _group;

    private Chair? _chair;

    private int _ageInYears;

    public Visitor(string email, DateTime dateOfBirth, DateTime? eventStartDate = null)
    {
        Email = email;
        _dateOfBirth = dateOfBirth;

        if (eventStartDate != null)
        {
            SetAge(eventStartDate.Value);
        }
    }

    public int GetGroupNumber()
    {
        return _group?.GetId() ?? -1;
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
        _ageInYears = CalculateAgeInYears(startDate);
    }

    public bool IsAssignedToChair()
    {
        return _chair != null;
    }

    public bool IsAdult()
    {
        return _ageInYears > 12;
    }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Email);
    }

    public void AssignChair(Chair chair)
    {
        chair.AssignVisitor(this);
        _chair = chair;
    }

    public void RevokeChair()
    {
        _chair?.RevokeVisitor();
        _chair = null;
    }

    public void AssignGroup(Group group)
    {
        _group = group;
    }

    public override string ToString()
    {
        return $"Age: {_ageInYears} - Group: {_group} - Email: {Email}";
    }
}