using System;

namespace Business.Interfaces;

public interface IFileService
{
    bool SaveContentToFile(string content);

    string ReadContentFromFile();

}
