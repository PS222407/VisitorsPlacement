namespace VisitorsPlacement._20_BusinessLogic.Models;

public class Group
{
    private static int _nextId;

    private readonly int _id;

    public List<Visitor> Visitors { get; private set; }

    public Group(Visitor visitor)
    {
        _id = Interlocked.Increment(ref _nextId);

        Visitors = new List<Visitor> { visitor };
        visitor.AssignGroup(this);
    }

    public Group(List<Visitor> visitors)
    {
        _id = Interlocked.Increment(ref _nextId);
        
        Visitors = visitors;
        foreach (Visitor visitor in visitors)
        {
            visitor.AssignGroup(this);
        }
    }

    public bool IsValid(DateTime startDateEvent)
    {
        bool containsAdult = Visitors.Any(v => v.IsAdult(startDateEvent));
        bool visitorsAreValid = Visitors.All(v => v.IsValid());
        bool visitorsHaveUniqueEmails = Visitors.Select(v => v.Email).Distinct().Count() == Visitors.Count;

        return containsAdult && visitorsAreValid && visitorsHaveUniqueEmails;
    }

    public override string ToString()
    {
        return _id.ToString();
    }
}