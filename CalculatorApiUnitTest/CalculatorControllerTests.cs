

namespace CalculatorApiUnitTest;

public class CalculatorControllerTests
{
    /// <summary>
    /// mock implemintaion of ICalculator
    /// </summary>
    private readonly Mock<ICalculator> repositoryMock;
    private readonly CalculatorApiController controller;
    public CalculatorControllerTests()
    {
        repositoryMock = new Mock<ICalculator>();
        controller = new CalculatorApiController(repositoryMock.Object);
    }
    /// <summary>
    /// check request body validation
    /// </summary>
    [Fact]
    public void Calculate_ValidRequest_ReturnsOkResult()
    {
        // Arrange

        repositoryMock.Setup(repo => repo.Calculate(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<string>()))
                      .Returns(15); // Mock the repository to return 15 for any input

        // Act
        var result = controller.CalculateNumbers(new CalculatorRequest { Number1 = "10", Number2 = "5" }, "+") as OkObjectResult;

        // Assert
        Assert.NotNull(result);

        // Extract the value from the anonymous type
        var resultValue = result.Value.GetType().GetProperty("Result").GetValue(result.Value, null);

        Assert.Equal(15, (double)resultValue);
    }

    /// <summary>
    /// Division tests
    /// </summary>
    [Fact]
    public void Calculate_Division_ReturnsCorrectResult()
    {
        // Arrange
        repositoryMock.Setup(repo => repo.Calculate(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<string>()))
                      .Returns(2); // Mock the repository to return 2 for any input

        // Act
        var result = controller.CalculateNumbers(new CalculatorRequest { Number1 = "10", Number2 = "5" }, "/") as OkObjectResult;

        // Assert
        Assert.NotNull(result);

        // Extract the value from the anonymous type
        var resultValue = result.Value.GetType().GetProperty("Result").GetValue(result.Value, null);

        Assert.Equal(2, (double)resultValue);
    }

    /// <summary>
    /// check division by zero operation
    /// </summary>
    [Fact]
    public void Calculate_Division_ByZero_ReturnsBadRequest()
    {
        // Arrange
        repositoryMock.Setup(repo => repo.Calculate(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<string>()))
                      .Throws(new InvalidOperationException("Cannot divide by zero"));

        // Act
        var result = controller.CalculateNumbers(new CalculatorRequest { Number1 = "10", Number2 = "0" }, "/") as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);

        // Extract the error message from the anonymous type
        var errorMessage = result.Value.GetType().GetProperty("Error").GetValue(result.Value, null);

        Assert.Equal("Cannot divide by zero", errorMessage);
    }
}
