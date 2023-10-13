namespace VisitorsPlacement._20_BusinessLogic.Models;

public class Group
{
    private static int _nextId;

    private readonly int _id;

    private const int MaxChildrenPerAdult = 9;

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
        bool containsEnoughAdults = ContainsEnoughAdults(startDateEvent);
        bool visitorsAreValid = Visitors.All(v => v.IsValid());
        bool visitorsHaveUniqueEmails = Visitors.Select(v => v.Email).Distinct().Count() == Visitors.Count;

        return containsEnoughAdults && visitorsAreValid && visitorsHaveUniqueEmails;
    }

    private bool ContainsEnoughAdults(DateTime startDateEvent)
    {
        int numberOfChildren = Visitors.Count(v => !v.IsAdult(startDateEvent));
        int numberOfAdults = Visitors.Count(v => v.IsAdult(startDateEvent));

        if (numberOfAdults < 1)
        {
            return false;
        }

        if (numberOfChildren > 0)
        {
            if ((int)Math.Ceiling(numberOfChildren / (double)numberOfAdults) > MaxChildrenPerAdult)
            {
                return false;
            }
        }

        return true;
    }

    public override string ToString()
    {
        return _id.ToString();
    }
}