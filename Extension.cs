public static class Extension
{
    public static string GetFullName(this Name name){
        return name.FirstName + ' ' + name.LastName;
    }
}