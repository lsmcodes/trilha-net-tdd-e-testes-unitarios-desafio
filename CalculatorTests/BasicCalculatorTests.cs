using Calculator.Interfaces;
using Calculator.Models;
using Moq;

namespace CalculatorTests;

public class BasicCalculatorTests
{
    private BasicCalculator _calculator = new();

    [Theory]
    [InlineData("2x9x10x4", new string[]{"2","9","10","4"}, 'x')]
    [InlineData("20/10/5", new string[]{"20","10","5"}, '/')]
    public void ShouldReturnArrayWithCorrectValues_WhenReceiveValidString(string expression, string[] expectedResult, char signal)
    {
        // Act
        string[] actualResult = _calculator.Format(expression, signal);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("1", '+', "2+2")]
    [InlineData("2", '-', "2-2")]
    public void ShouldCallCorrectMethod_WhenReceiveOption(string option, char signal, string expression)
    {
        // Arrange
        var mockCalculator = new Mock<ICalculator>();
        var mockConsole = new Mock<IConsole>();
        var calculator = new BasicCalculator(mockConsole.Object, mockCalculator.Object);
        
        mockConsole.Setup(x => x.ReadLine()).Returns(expression);

        // Act
        calculator.Calculate(option, signal);

        // Assert
        switch(option)
        {
            case "1":
                mockCalculator.Verify(x => x.Add(expression), Times.Once);
                break;
            case "2":
                mockCalculator.Verify(x => x.Subtract(expression), Times.Once);
                break;
        }
    }

    [Theory]
    [InlineData("2+5", 7)]
    [InlineData("3+2+4", 9)]
    public void ShouldReturnCorrectSum_WhenReceiveValidValues(string expression, double expectedResult)
    {
        // Act
        double actualResult = _calculator.Add(expression);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("10-3", 7)]
    [InlineData("7-4-2", 1)]
    public void ShouldReturnCorrectSubtraction(string expression, double expectedResult)
    {
        // Act
        double actualResult = _calculator.Subtract(expression);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("10/2", 5)]
    [InlineData("20/5/2", 2)]
    public void ShouldReturnCorrectDivision(string expression, double expectedResult)
    {
        // Act
        double actualResult = _calculator.Divide(expression);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void ShouldReturnExceptionWhenDivisorIsZero()
    {
        // Arrange
        string expression = "5/0";

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(expression));
    }

    [Theory]
    [InlineData("7x5", 35)]
    [InlineData("6x2x2", 24)]
    public void ShouldReturnCorrectMultiplication(string expression, double expectedResult)
    {
        // Act
        double actualResult = _calculator.Multiply(expression);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void ShoultReturnNonEmptyList()
    {
        // Arrange
        _calculator.Add("8+5");
        _calculator.Multiply("6x8");

        // Act
        List<string> history = _calculator.ShowHistory();

        // Assert
        Assert.NotEmpty(history);
    }
}