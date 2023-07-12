using System;
using System.Collections.Generic;

public class User
{
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _password;

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public List<SavingsGoal> SavingsGoals { get; set; } // Property to store savings goals

    public User()
    {
        SavingsGoals = new List<SavingsGoal>();
    }

    public User(string firstName, string lastName, string email, string password)
    {
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _password = password;
        SavingsGoals = new List<SavingsGoal>();
    }

    public User(string email, string password)
    {
        _email = email;
        _password = password;
        SavingsGoals = new List<SavingsGoal>();
    }

    public User CreateAccount(User newUser)
    {
        if (newUser == null)
        {
            throw new ArgumentNullException(nameof(newUser), "User object cannot be null.");
        }

        // Simulate account creation logic
        return newUser;
    }

    public User Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Invalid email or password.");
        }

        // Simulate login logic
        if (_email == email && _password == password)
        {
            return this;
        }

        return null;
    }
}
