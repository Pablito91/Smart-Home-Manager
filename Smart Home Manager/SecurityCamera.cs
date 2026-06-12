namespace SmartHomeManager;

public class SecurityCamera : SmartDevice
{
    public bool IsRecording { get; private set; }

    public SecurityCamera(string name) : base(name)
    {
        IsRecording = false;
    }

    public override void TurnOn()
    {
        base.TurnOn();
        IsRecording = true;
    }

    public override void TurnOff()
    {
        base.TurnOff();
        IsRecording = false;
    }

    public override string GetStatus()
    {
        return $"{ToString()} | Nagrywanie: {IsRecording}";
    }
}