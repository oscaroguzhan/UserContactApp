using System;
using Business.Helpers;

namespace Business_Test.Helpers;

public class IdGenerator_Tests
{
    [Fact]
    public void GenerateId_Should_Return_AGuidAsString()
    {
        
        // Act
        var result = IdGenerator.GenerateId();

        // Assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
        Assert.IsType<string>(result);

    }

}
