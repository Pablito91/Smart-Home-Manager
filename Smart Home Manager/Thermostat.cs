namespace SmartHomeManager;

public class Thermostat : SmartDevice, ISchedulable
{
    public double Temperature { get; set; }

    public Thermostat(string name, double temperature = 21.5) : base(name)
    {
        Temperature = temperature;
    }

    public void Schedule(string time)
    {
        Console.WriteLine($"Termostat {Name} zaplanowano na godzinę {time}.");
    }

    public override string GetStatus()
    {
        return $"{ToString()} | Temperatura: {Temperature}°C";
    }
}