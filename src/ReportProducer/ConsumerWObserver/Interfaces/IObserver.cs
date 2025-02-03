namespace ConsumerWObserver.Interfaces
{
    public interface IObserver
    {
        void OnFileCreated(string filePath);
    }
}