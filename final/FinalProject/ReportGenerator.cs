using System;

public class ReportGenerator
{
    public void GenerateReport(User user, string reportName)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User object cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(reportName))
        {
            throw new ArgumentException("Report name cannot be empty or null.");
        }

        Console.WriteLine($"Generating report for user: {user.FirstName} {user.LastName}, Report name: {reportName}");
        // Additional logic to generate the report
    }
}
