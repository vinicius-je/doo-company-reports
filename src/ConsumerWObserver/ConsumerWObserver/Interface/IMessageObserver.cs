namespace ConsumerWObserver.Interface;

public interface IMessageObserver
{
    void OnMessageReceived(string message);
}