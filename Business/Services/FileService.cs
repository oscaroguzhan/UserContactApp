// Purpose: FileService class for handling file operations.
using System.Diagnostics;
using Business.Interfaces;

namespace Business.Services;

public class FileService(string directoryPath, string filePath) : IFileService
{
    private readonly string _directoryPath = directoryPath;
    private readonly string _filePath = filePath;

    public string ReadContentFromFile()
    {
        if (File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }

        return string.Empty;
    }

    public bool SaveContentToFile(string content)
    {
        
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            File.WriteAllText(_filePath, content);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}