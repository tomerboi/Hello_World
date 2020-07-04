public class Person
{
    public Name FullName { get; set; }
    public Address Address { get; set; }

    public static string Hallo;
    public Person()
    {
        
    }
    public Person(Name name, Address address)
    {
        FullName = name;
        Address = address;
    }

    public void plusOne(string[] i){
        i[0] = "iu";
    }
    public static void Run(){

    }
}
