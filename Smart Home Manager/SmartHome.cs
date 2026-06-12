using System.Reflection;
using System.Text;

namespace SmartHomeManager;

public class SmartHome
{
    private readonly List<SmartDevice> _devices = new();

    public string HomeName { get; set; }

    public SmartHome(string homeName)
    {
        HomeName = homeName;
    }

    // Indeksator
    public SmartDevice this[int index]
    {
        get => _devices[index];
        set => _devices[index] = value;
    }

    public int Count => _devices.Count;

    public void AddDevice(SmartDevice device)
    {
        _devices.Add(device);

        device.DeviceStatusChanged += (sender, message) =>
        {
            Console.WriteLine($"ZDARZENIE: {sender.Name} -> {message}");
        };

        if (device is MotionSensor sensor)
        {
            sensor.MotionDetected += OnMotionDetected;
        }

        Console.WriteLine($"Dodano urządzenie: {device.Name}");
    }

    // Przeciążenie operatora +
    public static SmartHome operator +(SmartHome home, SmartDevice device)
    {
        home.AddDevice(device);
        return home;
    }

    public void ShowDevices()
    {
        if (_devices.Count == 0)
        {
            Console.WriteLine("Brak urządzeń w systemie.");
            return;
        }

        foreach (SmartDevice device in _devices)
        {
            Console.WriteLine(device);
        }
    }

    public void ShowStatuses()
    {
        foreach (SmartDevice device in _devices)
        {
            Console.WriteLine(device.GetStatus());
        }
    }

    public SmartDevice? FindById(int id)
    {
        return _devices.FirstOrDefault(d => d.Id == id);
    }

    public void TurnDeviceOn(int id)
    {
        FindById(id)?.TurnOn();
    }

    public void TurnDeviceOff(int id)
    {
        FindById(id)?.TurnOff();
    }

    public void NightMode()
    {
        Console.WriteLine("Uruchomiono tryb nocny.");

        foreach (SmartDevice device in _devices)
        {
            switch (device)
            {
                case SmartLight light:
                    light.Brightness = 20;
                    light.TurnOn();
                    break;

                case SmartLock smartLock:
                    smartLock.Lock();
                    break;

                case SecurityCamera camera:
                    camera.TurnOn();
                    break;

                case Thermostat thermostat:
                    thermostat.Temperature = 19.0;
                    break;
            }
        }
    }

    public void SimulateMotion()
    {
        foreach (SmartDevice device in _devices)
        {
            if (device is MotionSensor sensor)
            {
                sensor.DetectMotion();
                return;
            }
        }

        Console.WriteLine("Brak czujnika ruchu w systemie.");
    }

    private void OnMotionDetected(MotionSensor sensor)
    {
        Console.WriteLine($"SmartHome reaguje na ruch wykryty przez: {sensor.Name}");

        foreach (SmartDevice device in _devices)
        {
            if (device is SmartLight light)
            {
                light.TurnOn();
            }

            if (device is SecurityCamera camera)
            {
                camera.TurnOn();
            }
        }
    }

    public async Task SaveDevicesAsync(string fileName = "devices.txt")
    {
        StringBuilder sb = new();

        sb.AppendLine($"Smart Home: {HomeName}");
        sb.AppendLine($"Liczba urządzeń: {_devices.Count}");
        sb.AppendLine();

        foreach (SmartDevice device in _devices)
        {
            sb.AppendLine(device.GetStatus());
        }

        await File.WriteAllTextAsync(fileName, sb.ToString());

        Console.WriteLine($"Dane zapisano asynchronicznie do pliku: {fileName}");
    }

    public void ShowReflectionInfo(SmartDevice device)
    {
        Type type = device.GetType();

        Console.WriteLine($"Informacje diagnostyczne dla klasy: {type.Name}");
        Console.WriteLine();

        Console.WriteLine("Właściwości:");
        foreach (PropertyInfo property in type.GetProperties())
        {
            Console.WriteLine($"- {property.PropertyType.Name} {property.Name}");
        }

        Console.WriteLine();

        Console.WriteLine("Metody:");
        foreach (MethodInfo method in type.GetMethods(
                     BindingFlags.Public |
                     BindingFlags.Instance |
                     BindingFlags.DeclaredOnly))
        {
            Console.WriteLine($"- {method.ReturnType.Name} {method.Name}()");
        }
    }
}