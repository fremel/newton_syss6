public class UserRegistration
{
    private readonly List<string> _usernames = new List<string>();
 
    public bool RegisterUser(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Username cannot be null or empty.", nameof(username));
        }
 
        foreach(String nameInList in _usernames) {
            if(nameInList.ToLower().Equals(username.ToLower())) {
                return false; // Username already exists.
            }
        }
        _usernames.Add(username);
        return true;
    }
}