namespace VisitorsPlacement_20_BusinessLogic.Models;

public class Visitor
{
    public string Email { get; private set; }

    private readonly DateTime _dateOfBirth;

    private Group? _group;

    public Chair? Chair { get; private set; }

    public Visitor(string email, DateTime dateOfBirth)
    {
        Email = email;
        _dateOfBirth = dateOfBirth;
    }

    private int AgeInYears(DateTime dateToCompare)
    {
        int age = dateToCompare.Year - _dateOfBirth.Year;
        if (_dateOfBirth.AddYears(age) > dateToCompare)
        {
            age--;
        }

        return age;
    }

    public bool IsAdult(DateTime dateToCompare)
    {
        return AgeInYears(dateToCompare) > 12;
    }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Email) && _dateOfBirth < DateTime.Now;
    }

    public void AssignChair(Chair chair)
    {
        Chair = chair;
    }

    public void AssignGroup(Group group)
    {
        _group = group;
    }

    public override string ToString()
    {
        return $"Age: {AgeInYears(DateTime.Now)} - Group: {_group} - Email: {Email}";
    }
}