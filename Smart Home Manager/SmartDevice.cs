namespace SmartHomeManager;

public abstract class SmartDevice : IConnectable
{
    private static int _deviceCounter = 0;

    public int Id { get; }
    public string Name { get; set; }
    public bool IsOn { get; private set; }
    public bool IsConnected { get; set; }

    public static int DeviceCounter => _deviceCounter;

    public event Action<SmartDevice, string>? DeviceStatusChanged;

    protected SmartDevice(string name)
    {
        Id = ++_deviceCounter;
        Name = name;
        IsOn = false;
        IsConnected = false;
    }

    public virtual void TurnOn()
    {
        IsOn = true;
        OnDeviceStatusChanged("Urządzenie zostało włączone.");
    }

    public virtual void TurnOff()
    {
        IsOn = false;
        OnDeviceStatusChanged("Urządzenie zostało wyłączone.");
    }

    public virtual void Connect()
    {
        IsConnected = true;
        OnDeviceStatusChanged("Urządzenie połączone z siecią.");
    }

    public virtual void Disconnect()
    {
        IsConnected = false;
        OnDeviceStatusChanged("Urządzenie rozłączone z siecią.");
    }

    protected void OnDeviceStatusChanged(string message)
    {
        DeviceStatusChanged?.Invoke(this, message);
    }

    public abstract string GetStatus();

    public override string ToString()
    {
        return $"[{Id}] {Name} | Typ: {GetType().Name} | Włączone: {IsOn} | Połączone: {IsConnected}";
    }

    public static bool operator ==(SmartDevice? a, SmartDevice? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;

        return a.Id == b.Id;
    }

    public static bool operator !=(SmartDevice? a, SmartDevice? b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        return obj is SmartDevice device && Id == device.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}