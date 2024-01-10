using expensereport_csharp;
using NUnit.Framework;
using Shouldly;

namespace Tests
{
  public class BuildReportLineItemTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BuildsSingleLineItem()
    {
      var expense = new Expense() { Type = ExpenseType.BREAKFAST, Amount = 5 };
      var result = new ExpenseReport().BuildReportLineItem(expense);

      result.ShouldBe("Breakfast\t5\t ");
    }
  }
}