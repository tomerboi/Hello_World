using System;
using System.Threading;


public class TechLead : Worker
{
    public TechLead(Guid id, string name) : base(id,name)
    {
        m_tier = Tier.Tier2;
    }
    public override bool HandleCall(Call call)
    {
        m_isBusy = true;
        Thread.Sleep(1000);
        m_isBusy = false;
        return call.Tier == Tier.Tier2;      
    }
}