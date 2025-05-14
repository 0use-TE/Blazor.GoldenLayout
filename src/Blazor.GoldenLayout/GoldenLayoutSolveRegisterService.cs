namespace Blazor.GoldenLayout;

public class GoldenLayoutSolveRegisterService
{
    private Dictionary<string, int> GoldenLayoutSolveRegister { get; set; } = new Dictionary<string, int>();
    private Dictionary<string, int> GoldenLayoutSolveFinish { get; set; } = new Dictionary<string, int>();
    private event Func<string,Task>? OnRegisteredComponent;
  public int GetRegisterCount(string identity) => GoldenLayoutSolveRegister[identity];
    public void RegisterGoldenLayout(string identity)
    {
        GoldenLayoutSolveRegister.TryAdd(identity, 0);
        GoldenLayoutSolveFinish.TryAdd(identity, 0);
        GoldenLayoutSolveRegister[identity]++;
    }

    public void FinshRegisteredGoldenLayout(string identity)
    {
            GoldenLayoutSolveFinish[identity]++;
        if (GoldenLayoutSolveFinish[identity]>= GoldenLayoutSolveRegister[identity])
            OnRegisteredComponent?.Invoke(identity);
    }

    public void RegisterGoldenLayoutFinish(Func<string,Task> callback)
    {
        OnRegisteredComponent+=callback;
    }
    
}