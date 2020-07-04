using System;

public class Address : IComparable
{
    public string Street { get; set; }
    public string City { get; set; }

    public Address(string street, string city)
    {
        Street = street;
        City = city;
    }
    public int CompareTo(object obj)
    {
        Address address = (Address) obj;
        int compare = String.Compare(this.Street, address.Street) + String.Compare(this.City, address.City);
        return compare == 0 ? 0 : 1;
    }
}
