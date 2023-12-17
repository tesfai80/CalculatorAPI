namespace CalculatorAPI.Interfaces
{
    /// <summary>
    /// Interfaces for calculation 
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// calculates 2 numbers 
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="operator"></param>
        /// <returns></returns>
        double Calculate(double number1, double number2, string @operator);
    }
}
