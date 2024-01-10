using expensereport_csharp;
using NUnit.Framework;
using Shouldly;

namespace Tests
{
  public class BuildReportTests
  {
    private ExpenseReport expenseReport;

    [SetUp]
    public void Setup()
    {
      expenseReport = new ExpenseReport();
    }

    [Test]
    public void Test1()
    {
      Assert.Pass();
    }

    [Test]
    public void BasicMealExpense()
    {
      var result = expenseReport.BuildReport([new() { Type = ExpenseType.BREAKFAST, Amount = 5 }]);
      result.ShouldContain("Breakfast");
      result.ShouldContain("Meal Expenses: 5");
    }

    [Test]
    public void MealExpensesAreTotaled()
    {
      var result = expenseReport.BuildReport([
        new() { Type = ExpenseType.BREAKFAST, Amount = 5 },
        new() { Type = ExpenseType.DINNER, Amount = 5 }
      ]);
      result.ShouldContain("Breakfast");
      result.ShouldContain("Dinner");

      result.ShouldContain("Meal Expenses: 10");
    }

    [Test]
    public void CarRentalNotIncludedInMealExpenses()
    {
      var result = expenseReport.BuildReport([
        new() { Type = ExpenseType.CAR_RENTAL, Amount = 500 },
        new() { Type = ExpenseType.DINNER, Amount = 30 }
      ]);
      result.ShouldContain("Car Rental");
      result.ShouldContain("Dinner");

      result.ShouldContain("Meal Expenses: 30");
      result.ShouldContain("Total expenses: 530");
    }
  }
}