namespace PWATraining.Modules;
public class TestClass
{
    public string username;
    public string password;

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public TestClass(string username, string password)
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        this.username = username;
        this.password = password;
    }
    public string LoggedIn()
    {
        if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
        {
            return "No username or password entered";
        }
        else if (string.IsNullOrEmpty(username))
        {
            return "No username entered";
        }
        else if (string.IsNullOrEmpty(password))
        {
            return "No password entered";
        }
        else
        {
            return "Both username and password is entered";
        }
    }
}