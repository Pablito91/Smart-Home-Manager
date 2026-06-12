namespace SmartHomeManager;

public class SmartLock : SmartDevice
{
    public bool IsLocked { get; private set; }

    public SmartLock(string name) : base(name)
    {
        IsLocked = true;
    }

    public void Lock()
    {
        IsLocked = true;
        Console.WriteLine($"Zamek {Name} został zamknięty.");
    }

    public void Unlock()
    {
        IsLocked = false;
        Console.WriteLine($"Zamek {Name} został otwarty.");
    }

    public override string GetStatus()
    {
        return $"{ToString()} | Zamknięty: {IsLocked}";
    }
}