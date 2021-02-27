using System;
using System.Collections.Generic;
using Bakery.Models;


namespace Bakery
{
  public class Program
  {
    public static List<Bread> breadCart = new List<Bread> {};
    public static List<Pastry> pastryCart = new List<Pastry> {};

    public static void Main()
    {
      DrawChecker(20);
      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("        Welcome to Pierres Bakery!       ");
      Console.ResetColor();
      Console.WriteLine();
      InitialPrompt();
    }

    public static void InitialPrompt()
    {
      DrawChecker(20);
      Console.Write("Please select an option: (bread/pastry/checkout/exit): ");
      Action onFail = Program.InitialPrompt;
      string response = ParseInput(new List<string>{"bread","pastry","checkout","exit"},"Please enter a valid option", onFail);
      
      if (response.ToLower() == "bread")
      {
        DrawChecker(20);
        OrderBread();
      }
      if (response.ToLower() == "pastry")
      {
        DrawChecker(20);
        OrderPastry();
      }
      else if (response.ToLower() == "checkout")
      {
        DrawChecker(30);
        Checkout();
      }
      else if (response.ToLower() == "exit")
      {
        Console.WriteLine("GoodBye!");
      }
    }
    public static void OrderPastry()
    {
      Pastry pastryItem = new Pastry();
      Console.Write("How many pastries would you like to buy?: ");
      int amountToAdd = Int32.Parse(Console.ReadLine());

      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("Types of Pastries:");
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine();
      Console.Write("1   Flaky\n2   Puff\n3   ShortCrust\n4   Cinnamon rolls\n");
      Console.ResetColor();
      Console.WriteLine();

      Console.Write("What Type of pastrie would you like to buy? (flaky/puff/short/cinnamon): ");
      string type = Console.ReadLine();
      pastryItem.AddAmount(amountToAdd);
      pastryItem.SetBakeType(type);
      pastryCart.Add(pastryItem);
      InitialPrompt();
    }
    public static void OrderBread()
    {
      Bread breadItem = new Bread();
      Console.Write("How many loafs would you like to buy?: ");
      int amountToAdd = Int32.Parse(Console.ReadLine());

      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("Types of Bread:");
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine();
      Console.Write("1   Plain\n2   Garlic\n3   Sourdough\n4   Herbs\n");
      Console.ResetColor();
      Console.WriteLine();


      Console.Write("What Type of bread would you like to buy? (plain/garlic/sour/herb): ");
      string type = Console.ReadLine();
      breadItem.AddAmount(amountToAdd);
      breadItem.SetBakeType(type);
      breadCart.Add(breadItem);
      InitialPrompt();
    }
    public static void Checkout()
    {
      if (breadCart.Count == 0 && pastryCart.Count == 0)
        {
          Console.WriteLine("Order at least 1 item from shop before checking out");
          InitialPrompt();
        }
        else
        {
          int totalBreadCost = 0;
          int totalPastryCost = 0;

          Console.WriteLine("____________________");
          if (breadCart.Count != 0)
          {
            Console.WriteLine("Bread");
            foreach (Bread item in breadCart)
            {
              Console.WriteLine($"    Type:{item.GetBakeType()} Amount:{item.GetAmount()} Cost:${item.GetCost().ToString()}.00");
              totalBreadCost += item.GetCost();
            }
            Console.WriteLine($"    Bread Total: {totalBreadCost.ToString()}");
          }

          if (pastryCart.Count != 0)
          {
            Console.WriteLine("Pastries");
            foreach (Pastry item in pastryCart)
            {
              Console.WriteLine($"    Type:{item.GetBakeType()} Amount:{item.GetAmount()} Cost:${item.GetCost().ToString()}.00");
              totalPastryCost += item.GetCost();
            }
            Console.WriteLine($"    Pastry Total: {totalPastryCost.ToString()}");
          }
          Console.WriteLine("____________________");
          Console.WriteLine($"Total Order Cost: {(totalBreadCost + totalPastryCost).ToString()}");
          Console.WriteLine("Thank you for Shopping at Pierre's Bakery! Have a good day!");
        }
    }

    public static void DrawChecker(int length)
    {
      Console.BackgroundColor = ConsoleColor.Red;
      Console.Write(" ");
      System.Threading.Thread.Sleep(10);
      for (int i = 0; i<length; i++)
      {
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write(" ");
        System.Threading.Thread.Sleep(10);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" ");
        System.Threading.Thread.Sleep(10);
      }
      Console.ResetColor();
      Console.WriteLine();
      System.Threading.Thread.Sleep(50);
    }
    public static string ParseInput(List<string> acc, string error, Action callback)
    {
      string tested = Console.ReadLine();
      try
      {
        foreach(string tester in acc)
        {
          if (tested == tester)
          {
            return tested;
          }
        }
        Console.WriteLine(error);
        callback();
        return "fail";
      }
      catch (Exception e)
      {
        Console.WriteLine(error);
        callback();
        return "fail";
      }
    }
  }
}