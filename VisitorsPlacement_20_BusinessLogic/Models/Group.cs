namespace VisitorsPlacement_20_BusinessLogic.Models;

public class Group
{
    private static int _nextId;

    private readonly int _id;

    private const int MaxChildrenPerAdult = 9;

    public List<Visitor> Visitors { get; private set; }

    public DateTime RegistrationDate { get; set; }

    public Group(Visitor visitor, int? id = null)
    {
        if (id != null)
        {
            _id = id.Value;
        }
        else
        {
            _id = Interlocked.Increment(ref _nextId);
        }

        Visitors = new List<Visitor> { visitor };
        visitor.AssignGroup(this);
    }

    public Group(List<Visitor> visitors, int? id = null)
    {
        if (id != null)
        {
            _id = id.Value;
        }
        else
        {
            _id = Interlocked.Increment(ref _nextId);
        }

        Visitors = visitors;
        foreach (Visitor visitor in visitors)
        {
            visitor.AssignGroup(this);
        }
    }

    public int GetId()
    {
        return _id;
    }

    public List<Visitor> GetChildren()
    {
        return Visitors.Where(v => !v.IsAdult()).ToList();
    }

    public List<Visitor> GetAdults()
    {
        return Visitors.Where(v => v.IsAdult()).ToList();
    }

    public bool IsValid()
    {
        bool containsEnoughAdults = ContainsEnoughAdults();
        bool visitorsAreValid = Visitors.All(v => v.IsValid());
        bool visitorsHaveUniqueEmails = Visitors.Select(v => v.Email).Distinct().Count() == Visitors.Count;

        return containsEnoughAdults && visitorsAreValid && visitorsHaveUniqueEmails;
    }

    private bool ContainsEnoughAdults()
    {
        int numberOfChildren = GetChildren().Count;
        int numberOfAdults = GetAdults().Count;

        if (numberOfAdults < 1)
        {
            return false;
        }

        if (numberOfChildren <= 0) return true;

        return (int)Math.Ceiling(numberOfChildren / (double)numberOfAdults) <= MaxChildrenPerAdult;
    }

    public void SetVisitorsAge(DateTime startDate)
    {
        foreach (Visitor visitor in Visitors)
        {
            visitor.SetAge(startDate);
        }
    }

    public override string ToString()
    {
        return _id.ToString();
    }
}