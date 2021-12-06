using Xunit;
using Kiosk.App;

namespace Kiosk.Test;

// This is just an example of a unit test.
// Unit tests can make it easier to make changes to code that
// you expect other teams to call into.
//
// To run all tests, in the terminal do:
// > cd Kiosk.Test
// > dotnet test
//
// Try it! you should see a failing test. Then change a detail in the
// code below, or better yet in the ReadQuestionsFile method it invokes
// and you should see that the tests fails.


public class ReadTest
{
    [Fact]
    public void CanReadFile()
    {
        var readStep = new Read();
        Assert.NotEmpty(readStep.ReadQuestionsFile());
    }
}