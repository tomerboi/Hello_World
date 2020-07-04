
using System;

public delegate int myDel(int number);

public class Call : CallCenter
{
    public Tier Tier;
    public Call()
    {
        //m_tier = t;
    }

    public int AddNum(myDel f, int a)
    {
        try
        {
            return f(a);
        }
        catch
        {
            throw;
        }
        finally
        {
            int d = 5;
        }
    }
}