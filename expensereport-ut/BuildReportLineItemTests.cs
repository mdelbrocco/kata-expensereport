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
    public void BuildsSingleLineItem()
    {
      var expense = new Expense() { Type = ExpenseType.BREAKFAST, Amount = 5 };
      var result = expenseReport.BuildReportLineItem(expense);

      result.ShouldBe("Breakfast\t5\t ");
    }

    [Test]
    public void BreakfastOverLimit()
    {
      var expense = new Expense() { Type = ExpenseType.BREAKFAST, Amount = ExpenseReport.LimitBreakfast + 1 };
      var result = expenseReport.BuildReportLineItem(expense);

      result.ShouldEndWith("X");
    }

    [Test]
    public void DinnerOverLimit()
    {
      var expense = new Expense() { Type = ExpenseType.DINNER, Amount = ExpenseReport.LimitDinner + 1 };
      var result = expenseReport.BuildReportLineItem(expense);

      result.ShouldEndWith("X");
    }
  }
}