using System;

public class Name : IComparable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName; 
    }
    public int CompareTo(object obj)
    {
        Name name = (Name)obj;
        int compare = String.Compare(this.FirstName, name.FirstName) + String.Compare(this.LastName, name.LastName);
        return compare == 0 ? 0 : 1;
    }
}
