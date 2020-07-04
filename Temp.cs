using System;

public static class Temp
{
    public static string FirstName { get; set; }
    public static string LastName { get; set; }

    static Temp()
    {
        FirstName = "firstName";
        LastName = "lastName"; 
    }
}
