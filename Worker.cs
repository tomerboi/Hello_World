using System;

public enum Tier {
    Tier1, 
    Tier2,
    Tier3
}
public abstract class Worker : IWorker
{
    private Guid m_guid;
    public string m_name;
    protected bool m_isBusy;
    protected Tier m_tier {get; set;}
    public Worker(Guid id, string name)
    {
        m_guid = id;
        m_name = name;
        m_isBusy = false;
    }
    public abstract bool HandleCall(Call call);

    public bool IsBusy()
    {
        return m_isBusy;
    }
}