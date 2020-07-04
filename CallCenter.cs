using System;
using System.Collections.Generic;

public class CallCenter : ICallCenter
{
    private Stack<IWorker> m_freeWorkers;
    private Stack<IWorker> m_workingWorkers;
    private Queue<Call> m_calls;
    private IWorker m_techLead;
    private IWorker m_manager;

    private readonly Name m_str;

    private const string m_sss = "dad";
    public readonly int m_int = 10;
    public CallCenter()
    {
        HashSet<IWorker> m_hashSet;
        
        m_freeWorkers = new Stack<IWorker>();
        m_workingWorkers = new Stack<IWorker>();
        m_calls = new Queue<Call>();
        m_techLead = new TechLead(Guid.NewGuid(), "Asher");
        m_manager = new Manager(Guid.NewGuid(), "Leo");
        m_str = new Name("dd","");
        m_str = new Name("dd","dd");
        m_int = 18;
        InitWorkers();
    }

    private void InitWorkers()
    {
        for (int i = 0; i < 7; i++)
        {
            m_freeWorkers.Push(new Fresher(Guid.NewGuid(), "Tomer" + i));
        }
    }

    public void GetCallHandler(Call call)
    {
        if (m_freeWorkers.Count > 0)
        {
            IWorker worker = m_freeWorkers.Pop();
            if (worker == null)
            {
                m_calls.Enqueue(call);
            }
            m_workingWorkers.Push(worker);
            if (!worker.HandleCall(call))
            {
                m_freeWorkers.Push(m_workingWorkers.Pop());
                if (!m_techLead.IsBusy())
                {
                    if (!m_techLead.HandleCall(call))
                    {
                        if (!m_manager.IsBusy())
                        {
                            m_manager.HandleCall(call);
                        }
                        m_calls.Enqueue(call);
                    }
                }
                else
                {
                    if (!m_manager.IsBusy())
                    {
                        m_manager.HandleCall(call);
                    }
                    else
                    {
                        m_calls.Enqueue(call);
                    }
                }
            }
        }
    }
}