namespace CalculatorAPI.Interfaces
{
    /// <summary>
    /// interface for user operation
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Login Process
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string Login(string userName, string password);
    }
}
