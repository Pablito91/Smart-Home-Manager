using SmartHomeManager;

SmartHome home = new SmartHome("Dom Pawła");

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("=== SMART HOME MANAGER ===");
    Console.WriteLine("1. Dodaj urządzenie");
    Console.WriteLine("2. Wyświetl listę urządzeń");
    Console.WriteLine("3. Włącz urządzenie");
    Console.WriteLine("4. Wyłącz urządzenie");
    Console.WriteLine("5. Sprawdź status urządzeń");
    Console.WriteLine("6. Tryb nocny");
    Console.WriteLine("7. Symuluj wykrycie ruchu");
    Console.WriteLine("8. Zapisz dane do pliku async");
    Console.WriteLine("9. Refleksja - diagnostyka klasy");
    Console.WriteLine("10. Test indeksatora home[0]");
    Console.WriteLine("0. Wyjście");
    Console.Write("Wybierz opcję: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddDeviceMenu(home);
            break;

        case "2":
            home.ShowDevices();
            Console.WriteLine($"Liczba wszystkich utworzonych urządzeń: {SmartDevice.DeviceCounter}");
            break;

        case "3":
            Console.Write("Podaj Id urządzenia: ");
            if (int.TryParse(Console.ReadLine(), out int onId))
                home.TurnDeviceOn(onId);
            break;

        case "4":
            Console.Write("Podaj Id urządzenia: ");
            if (int.TryParse(Console.ReadLine(), out int offId))
                home.TurnDeviceOff(offId);
            break;

        case "5":
            home.ShowStatuses();
            break;

        case "6":
            home.NightMode();
            break;

        case "7":
            home.SimulateMotion();
            break;

        case "8":
            await home.SaveDevicesAsync();
            break;

        case "9":
            Console.Write("Podaj Id urządzenia: ");
            if (int.TryParse(Console.ReadLine(), out int reflectionId))
            {
                SmartDevice? device = home.FindById(reflectionId);

                if (device != null)
                    home.ShowReflectionInfo(device);
                else
                    Console.WriteLine("Nie znaleziono urządzenia.");
            }
            break;

        case "10":
            if (home.Count > 0)
                Console.WriteLine($"Pierwsze urządzenie przez indeksator: {home[0].GetStatus()}");
            else
                Console.WriteLine("Brak urządzeń.");
            break;

        case "0":
            running = false;
            break;

        default:
            Console.WriteLine("Nieprawidłowa opcja.");
            break;
    }
}

static void AddDeviceMenu(SmartHome home)
{
    Console.WriteLine();
    Console.WriteLine("Wybierz typ urządzenia:");
    Console.WriteLine("1. Inteligentne światło");
    Console.WriteLine("2. Termostat");
    Console.WriteLine("3. Kamera");
    Console.WriteLine("4. Czujnik ruchu");
    Console.WriteLine("5. Inteligentny zamek");
    Console.Write("Opcja: ");

    string? type = Console.ReadLine();

    Console.Write("Podaj nazwę urządzenia: ");
    string name = Console.ReadLine() ?? "Nowe urządzenie";

    SmartDevice? device = type switch
    {
        "1" => new SmartLight(name),
        "2" => new Thermostat(name),
        "3" => new SecurityCamera(name),
        "4" => new MotionSensor(name),
        "5" => new SmartLock(name),
        _ => null
    };

    if (device == null)
    {
        Console.WriteLine("Nieprawidłowy typ urządzenia.");
        return;
    }

    home += device;
}