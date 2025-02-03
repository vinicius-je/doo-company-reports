using System;
using System.Collections.Generic;
using System.IO;
using ConsumerWObserver.Interfaces;

namespace ConsumerWObserver.Observers
{
    public class FileSystemNotifier
    {
        private readonly List<IObserver> _observers = new();
        private readonly string _directoryPath;
        private readonly FileSystemWatcher _watcher;

        public FileSystemNotifier(string directoryPath)
        {
            _directoryPath = directoryPath ?? throw new ArgumentNullException(nameof(directoryPath));

            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            _watcher = new FileSystemWatcher(_directoryPath)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                Filter = "*.*", // Monitorar todos os tipos de arquivos
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };

            // Eventos
            _watcher.Created += OnFileCreated;
        }

        public void RegisterObserver(IObserver observer)
        {
            if (observer == null) throw new ArgumentNullException(nameof(observer));
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Arquivo criado: {e.Name}");

            // Notificar todos os observadores
            foreach (var observer in _observers)
            {
                observer.OnFileCreated(e.FullPath);
            }
        }
    }
}