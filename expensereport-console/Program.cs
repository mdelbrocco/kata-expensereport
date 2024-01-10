using expensereport_csharp;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

new ExpenseReport().PrintReport([new() { Type = ExpenseType.BREAKFAST, Amount = 5 }]);