namespace VisitorsPlacement_20_BusinessLogic.Models;

public class Group
{
    private static int _nextId;

    private readonly int _id;

    public const int MaxChildrenPerAdult = 9;

    public List<Visitor> Visitors { get; private set; }

    public DateTime RegistrationDate { get; set; }

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
    
    public int GetId()
    {
        return _id;
    }

    public int GetNumberOfAdultsWatchingChildren()
    {
        return (int)Math.Ceiling((double)GetChildren().Count / MaxChildrenPerAdult);
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

        if (numberOfChildren > 0)
        {
            if ((int)Math.Ceiling(numberOfChildren / (double)numberOfAdults) > MaxChildrenPerAdult)
            {
                return false;
            }
        }

        return true;
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

    // public bool FitsInSection(DateTime eventStartDate, Section section)
    // {
    //     List<Visitor> children = GetChildren(eventStartDate).Where(v => !v.IsAssignedToChair()).ToList();
    //     List<Visitor> adults = GetAdults(eventStartDate).Where(v => !v.IsAssignedToChair()).ToList();
    //
    //     if (children.Count > )
    //     {
    //         
    //     }
    //
    //     Chair? chair = section.GetNextColumnChair(1);
    //     if (chair == null)
    //     {
    //         return false;
    //     }
    //     
    //     adults.First().TryAssignChair(chair);
    //     foreach (Visitor visitor in children)
    //     {
    //         Chair? chair1 = section.GetNextColumnChair(1);
    //         if (chair1 == null)
    //         {
    //             break;
    //         }
    //         visitor.TryAssignChair(chair1);
    //     }
    // }
}