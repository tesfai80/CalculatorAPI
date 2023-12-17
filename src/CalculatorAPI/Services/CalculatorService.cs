using CalculatorAPI.Interfaces;
using System;

namespace CalculatorAPI.Services
{ /// <summary>
  /// calculator service class for implementimg the interface
  /// </summary>
    public class CalculatorService : ICalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="operator"></param>
        /// <returns>result of calculation</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public double Calculate(double number1, double number2, string @operator)
        {
            // calculation logic based on the operator
            // For simplicity, assuming simple arithmetic operation 
            switch (@operator)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number2 - number1;
                case "*":
                    return number1 * number2;
                case "/":
                    if (number2 == 0)
                    {
                        throw new ArgumentException("Cannot divide by zero");
                    }
                    else
                        return number1 / number2;
                default:
                    throw new InvalidOperationException("Invalid operation. Supported operations: add, subtract, multiply, divide.");
            }
        }
    }
}
