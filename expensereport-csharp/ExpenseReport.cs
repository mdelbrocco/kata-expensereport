using System;
using System.Collections.Generic;
using System.Text;

namespace expensereport_csharp
{
  public enum ExpenseType
  {
    DINNER, BREAKFAST, CAR_RENTAL
  }

  public class Expense
  {
    public ExpenseType Type { get; set; }
    public int Amount { get; set; }
  }

  public class ExpenseReport(/*TimeProvider timeProvider = null*/)
  {
    public const int LimitBreakfast = 1000;
    public const int LimitDinner = 5000;

    //private readonly TimeProvider _timeProvider = timeProvider;
    public void PrintReport(List<Expense> expenses)
    {
      Console.WriteLine(BuildReport(expenses));
    }

    public string BuildReport(List<Expense> expenses)
    {
      int total = 0;
      int mealExpenses = 0;

      //var foo = _timeProvider.GetLocalNow();

      var sb = new StringBuilder(); // or use something like TextWriter = Console.Out
      sb.AppendLine("Expenses " + DateTime.Now);

      foreach (Expense expense in expenses)
      {
        if (expense.Type == ExpenseType.DINNER || expense.Type == ExpenseType.BREAKFAST)
        {
          mealExpenses += expense.Amount;
        }

        sb.Append(BuildReportLineItem(expense));

        total += expense.Amount;
      }

      sb.AppendLine("Meal expenses: " + mealExpenses);
      sb.AppendLine("Total expenses: " + total);

      return sb.ToString();
    }

    public string BuildReportLineItem(Expense expense)
    {
      var expenseName = "";
      switch (expense.Type)
      {
        case ExpenseType.DINNER:
          expenseName = "Dinner";
          break;
        case ExpenseType.BREAKFAST:
          expenseName = "Breakfast";
          break;
        case ExpenseType.CAR_RENTAL:
          expenseName = "Car Rental";
          break;
      }

      var mealOverExpensesMarker =
          expense.Type == ExpenseType.DINNER && expense.Amount > LimitDinner ||
          expense.Type == ExpenseType.BREAKFAST && expense.Amount > LimitBreakfast
              ? "X"
              : " ";

      return expenseName + "\t" + expense.Amount + "\t" + mealOverExpensesMarker;
    }
  }
}