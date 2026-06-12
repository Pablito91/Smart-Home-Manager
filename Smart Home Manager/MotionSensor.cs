namespace SmartHomeManager;

public class MotionSensor : SmartDevice
{
    public event Action<MotionSensor>? MotionDetected;

    public MotionSensor(string name) : base(name)
    {
    }

    public void DetectMotion()
    {
        Console.WriteLine($"Czujnik {Name}: wykryto ruch!");
        MotionDetected?.Invoke(this);
    }

    public override string GetStatus()
    {
        return $"{ToString()} | Gotowy do wykrywania ruchu";
    }
}