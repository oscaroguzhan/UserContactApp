using System;
using Business.Interfaces;
using Business.Services;

namespace Business_Test.Services;

public class FileService_Tests
{
    [Fact]
    public void SaveContentToFile_ShouldSaveContentToAFile() {
        // arrange
        var content = "test";
        var fileName = $"{Guid.NewGuid}.json";
        IFileService fileService = new FileService(fileName, "defaultPath");
        
        try
        {
            // act
            var result = fileService.SaveContentToFile(content);
            //assert
            Assert.True(result);
        }
        finally
        {
            
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            
        }

    }

    [Fact]
    public void GetContentFromFile_ShouldReturnContentFromFile() {
        // arrange
        var expected = "test";
        var fileName = @$"c:\projects\{Guid.NewGuid}.json";
        
        IFileService fileService = new FileService(fileName, "defaultPath");
        fileService.SaveContentToFile(expected);
        try
        {
            // act
            var result = fileService.ReadContentFromFile();
            //assert
            Assert.Equal(expected, result);
        }
        finally
        {
            
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            
        }
    }
}
