using System;
using System.IO;
using ConsumerWObserver.Interfaces;

namespace ConsumerWObserver.Observers
{
    public class ValidationObserver : IObserver
    {
        public void OnFileCreated(string filePath)
        {
            Console.WriteLine($"Validação iniciada para o arquivo: {filePath}");

            if (ValidateFile(filePath))
            {
                Console.WriteLine($"Arquivo {Path.GetFileName(filePath)} validado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Arquivo {Path.GetFileName(filePath)} falhou na validação.");
            }
        }

        private bool ValidateFile(string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                return fileInfo.Exists && fileInfo.Length > 0; // Exemplo simples: garantir que o arquivo não está vazio
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao validar arquivo {filePath}: {ex.Message}");
                return false;
            }
        }
    }
}