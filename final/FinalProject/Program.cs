using System;

class Program
{
    static void Main(string[] args)
    {
        bool loggedIn = false;
        User loggedInUser = null;

        while (true)
        {
            Console.WriteLine("MoneyMaster Program");

            User user = new User();
            ExpenseTracker expenseTracker = new ExpenseTracker();
            BudgetManager budgetManager = new BudgetManager();
            FinancialInsights financialInsights = new FinancialInsights();
            SavingsGoal savingsGoal = new SavingsGoal();
            ReportGenerator reportGenerator = new ReportGenerator();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter your last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter your email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string password = Console.ReadLine();

                        User newUser = new User(firstName, lastName, email, password);
                        loggedInUser = user.CreateAccount(newUser);
                        loggedIn = true;

                        Console.WriteLine("Account created successfully.");
                        break;
                    case "2":
                        Console.Write("Enter your email: ");
                        string loginEmail = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string loginPassword = Console.ReadLine();

                        loggedInUser = user.Login(loginEmail, loginPassword);

                        if (loggedInUser != null)
                        {
                            loggedIn = true;
                            Console.WriteLine("Login successful.");
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Please try again.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (loggedIn)
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. Set Budget");
                Console.WriteLine("3. Analyze Expenses");
                Console.WriteLine("4. Set Savings Goal");
                Console.WriteLine("5. Generate Report");
                Console.WriteLine("6. Logout");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        if (!loggedIn)
                        {
                            Console.WriteLine("You must be logged in to add an expense.");
                            break;
                        }

                        Console.Write("Enter expense category: ");
                        string category = Console.ReadLine();
                        Console.Write("Enter expense amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        Expense expense = new Expense(category, amount);
                        expenseTracker.AddExpense(loggedInUser, expense);

                        Console.WriteLine("Expense added successfully.");
                        break;
                    case "2":
                        if (!loggedIn)
                        {
                            Console.WriteLine("You must be logged in to set a budget.");
                            break;
                        }

                        Console.Write("Enter budget category: ");
                        string budgetCategory = Console.ReadLine();
                        Console.Write("Enter budget amount: ");
                        double budgetAmount = Convert.ToDouble(Console.ReadLine());

                        Budget budget = new Budget(budgetCategory, budgetAmount);
                        budgetManager.SetBudget(loggedInUser, budget);

                        Console.WriteLine("Budget set successfully.");
                        break;
                    case "3":
                        if (!loggedIn)
                        {
                            Console.WriteLine("You must be logged in to analyze expenses.");
                            break;
                        }

                        List<Expense> userExpenses = expenseTracker.GetExpenses(loggedInUser);

                        if (userExpenses.Count == 0)
                        {
                            Console.WriteLine("No expenses recorded.");
                        }
                        else
                        {
                            financialInsights.AnalyzeExpenses(userExpenses);

                            Console.WriteLine("Expense Analysis:");
                            foreach (var categoryExpense in financialInsights.ExpenseCategories)
                            {
                                Console.WriteLine($"{categoryExpense.Category}: {categoryExpense.Amount}");
                            }

                            double totalExpenses = 0;
                            foreach (var userExpense in userExpenses)
                            {
                                totalExpenses += userExpense.Amount;
                            }

                            Console.WriteLine($"Total Expenses: {totalExpenses}");
                        }
                        break;

                    case "4":
                        if (!loggedIn)
                        {
                            Console.WriteLine("You must be logged in to set a savings goal.");
                            break;
                        }

                        Console.Write("Enter savings goal name: ");
                        string goalName = Console.ReadLine();
                        Console.Write("Enter savings goal amount: ");
                        double goalAmount = Convert.ToDouble(Console.ReadLine());

                        SavingsGoal.SetSavingsGoal(loggedInUser, goalName, goalAmount);

                        Console.WriteLine("Savings goal set successfully.");
                        break;
                    case "5":
                        if (!loggedIn)
                        {
                            Console.WriteLine("You must be logged in to generate a report.");
                            break;
                        }

                        Console.Write("Enter report name: ");
                        string reportName = Console.ReadLine();

                        reportGenerator.GenerateReport(loggedInUser, reportName);

                        Console.WriteLine("Report generated successfully.");
                        break;
                    case "6":
                        if (!loggedIn)
                        {
                            Console.WriteLine("You are not logged in.");
                            break;
                        }

                        loggedIn = false;
                        loggedInUser = null;

                        Console.WriteLine("Logout successful.");

                        // Restart the program loop by breaking out of the current loop
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!loggedIn)
                {
                    break;
                }
            }
        }
    }
}
