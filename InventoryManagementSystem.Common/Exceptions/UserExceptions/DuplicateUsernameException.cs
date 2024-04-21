namespace InventoryManagementSystem.Common.Exceptions.UserExceptions;
public class DuplicateUsernameException : Exception
{
    public DuplicateUsernameException(string username)
        : base($"Username '{username}' is already taken.")
    {
    }
}
