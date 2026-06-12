namespace SmartHomeManager;

public interface IConnectable
{
    bool IsConnected { get; set; }
    void Connect();
    void Disconnect();
}

public interface ISchedulable
{
    void Schedule(string time);
}