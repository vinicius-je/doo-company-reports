using System;
using ConsumerWObserver.Interfaces;

namespace ConsumerWObserver.Observers
{
    public class NewFileObserver : IObserver
    {
        public void OnFileCreated(string filePath)
        {
            Console.WriteLine($"Novo arquivo detectado pelo NewFileObserver: {filePath}");
            // Ações adicionais, como logging ou notificação
        }
    }
}