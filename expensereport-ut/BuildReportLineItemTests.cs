using expensereport_csharp;
using NUnit.Framework;
using Shouldly;

namespace Tests
{
  public class BuildReportLineItemTests
  {
    private ExpenseReport expenseReport;
    [SetUp]
    public void Setup()
    {
      expenseReport = new ExpenseReport();
    }

    [Test]
    public void BreakfastUnderLimit()
    {
      var expense = new Expense() { Type = ExpenseType.BREAKFAST, Amount = ExpenseReport.LimitBreakfast - 1 };
      var result = expenseReport.BuildReportLineItem(expense);

      result.ShouldStartWith("Breakfast");
      result.ShouldEndWith(" ");
    }

    [Test]
    public void LunchUnderLimit()
    {
      var expense = new Expense() { Type = ExpenseType.LUNCH, Amount = ExpenseReport.LimitLunch - 1 };
      var result = expenseReport.BuildReportLineItem(expense);

      result.ShouldStartWith("Lunch");
      result.ShouldEndWith(" ");
    }

    [Test]
    public void DinnerUnderLimit()
    {
      var expense = new Expense() { Type = ExpenseType.DINNER, Amount = ExpenseReport.LimitDinner - 1 };
      var result = expenseReport.BuildReportLineItem(expense);

      result.ShouldStartWith("Dinner");
      result.ShouldEndWith(" ");
    }

    [Test]
    public void BreakfastOverLimit()
    {
      var expense = new Expense() { Type = ExpenseType.BREAKFAST, Amount = ExpenseReport.LimitBreakfast + 1 };
      var result = expenseReport.BuildReportLineItem(expense);

      result.ShouldStartWith("Breakfast");
      result.ShouldEndWith("X");
    }

    [Test]
    public void LunchOverLimit()
    {
      var expense = new Expense() { Type = ExpenseType.LUNCH, Amount = ExpenseReport.LimitLunch + 1 };
      var result = expenseReport.BuildReportLineItem(expense);

      result.ShouldStartWith("Lunch");
      result.ShouldEndWith("X");
    }

    [Test]
    public void DinnerOverLimit()
    {
      var expense = new Expense() { Type = ExpenseType.DINNER, Amount = ExpenseReport.LimitDinner + 1 };
      var result = expenseReport.BuildReportLineItem(expense);

      result.ShouldStartWith("Dinner");
      result.ShouldEndWith("X");
    }
  }
}