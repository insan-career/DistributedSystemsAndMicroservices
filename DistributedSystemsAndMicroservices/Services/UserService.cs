using System.Text.RegularExpressions;
using DistributedSystemsAndMicroservices.Models;

namespace DistributedSystemsAndMicroservices.Services;

public class UserService
{
    private static readonly List<User> Users = new List<User>();
    public List<User> GetAllUsers()
    {
        return Users.ToList(); // Return a copy to avoid modifying original list
    }

    public User? GetUserById(int id)
    {
        var user =  Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            throw new ArgumentException($"User with ID {id} not found.");
        }
        return user;
    }
    
    public bool AddUser(User user)
    {
        var userEmailValid = user.Email != null && IsValidEmail(user.Email);
        if (!userEmailValid)
        {
            return false;
        }
        
        var existingUser = Users.FirstOrDefault(u => u.Email == user.Email);
        if (existingUser != null)
        {
            return false;
        }
        
        user.Id = Users.Count + 1;
        Users.Add(user);
        return true;
    }
    
    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Adjust the regular expression as needed
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        catch (RegexParseException)
        {
            return false;
        }
    }

}
