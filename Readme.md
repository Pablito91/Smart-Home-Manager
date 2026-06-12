# Smart Home Manager

Paweł Bejger 80715

## Opis projektu

**Smart Home Manager** to aplikacja konsolowa napisana w języku **C\# (.NET 8)**, której zadaniem jest symulacja działania inteligentnego domu.

Program umożliwia zarządzanie inteligentnymi urządzeniami, takimi jak:

- inteligentne światło,

- termostat,

- kamera bezpieczeństwa,

- czujnik ruchu,

- inteligentny zamek drzwi.


# Funkcjonalności programu

Program umożliwia:

- dodawanie urządzeń do systemu,

- wyświetlanie listy urządzeń,

- włączanie i wyłączanie urządzeń,

- sprawdzanie statusu urządzeń,

- obsługę trybu nocnego,

- symulację wykrycia ruchu,

- zapis danych do pliku asynchronicznie,

- wyświetlanie informacji diagnostycznych przy użyciu refleksji,

- obsługę zdarzeń urządzeń.


# Wymagania projektowe

| Wymaganie | Gdzie zostało użyte |
| - | - |
| 1. Klasy | `SmartHome`, `SmartDevice`, `SmartLight`, `Thermostat`, `SecurityCamera`, `MotionSensor`, `SmartLock` |
| 2. Konstruktory | Konstruktory w każdej klasie urządzenia, np. `SmartLight(string name)` |
| 3. Właściwości / Indeksator | `Name`, `IsOn`, `Temperature`, indeksator `home\[index\]` |
| 4. Statyczne | `DeviceCounter` w klasie `SmartDevice` |
| 5. Dziedziczenie | Wszystkie urządzenia dziedziczą po `SmartDevice` |
| 6. Polimorfizm | Lista `List\<SmartDevice\>` oraz metoda `GetStatus()` |
| 7. Interfejsy / Abstrakcja | `IConnectable`, `ISchedulable`, abstrakcyjna klasa `SmartDevice` |
| 8. Typy ogólne / Kolekcje | `List\<SmartDevice\>` |
| 9. Delegaty / Zdarzenia | `MotionDetected`, `DeviceStatusChanged` |
| 10. Przeciążanie operatorów | Operatory `+`, `==`, `!=` |
| 11. Programowanie asynchroniczne | `SaveDevicesAsync()` z użyciem `async/await` |
| 12. Refleksja | `ShowReflectionInfo()` wykorzystująca `Reflection` |



# Dodatkowe elementy

W projekcie dodatkowo wykorzystano:

- menu konsolowe,

- walidację danych użytkownika (`int.TryParse()`),

- zapis danych do pliku tekstowego,

- `StringBuilder`,

- LINQ (`FirstOrDefault()`),

- hermetyzację danych (`private set`),

- `override` oraz `virtual`,

- metodę `ToString()`,

- organizację projektu w wielu plikach,

- dynamiczną obsługę zdarzeń,

- namespace,

- `switch expression.`

