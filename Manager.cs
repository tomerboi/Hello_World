using System;
using System.Threading;
        
public class Manager : Worker
{
    public Manager(Guid id, string name) : base(id,name)
    {
        m_tier = Tier.Tier3;
    }
    public override bool HandleCall(Call call)
    {
        m_isBusy = true;
        Thread.Sleep(1000);
        m_isBusy = false;
        return true;
    }
}