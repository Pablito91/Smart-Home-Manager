namespace SmartHomeManager;

public class SmartLight : SmartDevice, ISchedulable
{
    public int Brightness { get; set; }

    public SmartLight(string name, int brightness = 50) : base(name)
    {
        Brightness = brightness;
    }

    public void Schedule(string time)
    {
        Console.WriteLine($"Światło {Name} zaplanowano na godzinę {time}.");
    }

    public override string GetStatus()
    {
        return $"{ToString()} | Jasność: {Brightness}%";
    }
}