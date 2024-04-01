namespace InventoryManagementSystem.Common.Exceptions.UserExceptions;
public class InvalidPasswordException : Exception
{
    public InvalidPasswordException(string message) : base(message) { }
}
