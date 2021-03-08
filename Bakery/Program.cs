using System;
using System.Collections.Generic;
using Bakery.Models;

namespace Bakery
{
  public class Program
  {
    public static List<Bread> breadCart = new List<Bread> {};
    public static List<Pastry> pastryCart = new List<Pastry> {};
    public static Pastry activePastry;
    public static Bread activeBread;

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
        activeBread = new Bread();
        OrderBreadAmount();
      }
      if (response.ToLower() == "pastry")
      {
        DrawChecker(20);
        activePastry = new Pastry();
        OrderPastryAmount();
      }
      else if (response.ToLower() == "checkout")
      {
        DrawChecker(30);
        Checkout();
        System.Environment.Exit(1);
      }
      else if (response.ToLower() == "exit")
      {
        Console.WriteLine("GoodBye!");
        System.Environment.Exit(1);
      }
    }
    public static void OrderPastryAmount()
    {
      Console.Write("How many pastries would you like to buy?: ");
      Action onFail = Program.OrderPastryAmount;
      int amountToAdd = Int32.Parse(ParseInput(new List<string> {"num"},"Please enter a Number", onFail));
      activePastry.AddAmount(amountToAdd);
      OrderPastryType();
    }
    public static void OrderPastryType()
    {
      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("Types of Pastries:");
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine();
      Console.Write("Flaky   \nPuff   \nShortCrust   \nCinnamon rolls   ");
      Console.ResetColor();
      Console.WriteLine();
      Console.Write("What Type of pastrie would you like to buy? (flaky/puff/short/cinnamon): ");
      Action onFail = Program.OrderPastryType;
      string type = ParseInput(new List<string> {"flaky","puff","short","cinnamon"},"Please enter a valid option", onFail);
      activePastry.SetBakeType(type);
      Console.WriteLine("Your Selection has been added to checkout");
      pastryCart.Add(activePastry);
      InitialPrompt();
    }
    public static void OrderBreadAmount()
    {
      activeBread = new Bread();
      Console.Write("How many loafs would you like to buy?: ");
      Action onFail = Program.OrderBreadAmount;
      int amountToAdd = Int32.Parse(ParseInput(new List<string> {"num"},"Please enter a Number", onFail));
      activeBread.AddAmount(amountToAdd);
      OrderBreadType();
    }
    public static void OrderBreadType()
    {
      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("Types of Bread:");
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine();
      Console.Write("Plain   \nGarlic   \nSourdough   \nHerbs   ");
      Console.ResetColor();
      Console.WriteLine();
      Console.Write("What Type of bread would you like to buy? (plain/garlic/sour/herb): ");
      Action onFail = Program.OrderBreadType;
      string type = ParseInput(new List<string> { "plain", "garlic", "sour", "herb" }, "Please select a valid option", onFail);
      activeBread.SetBakeType(type);
      Console.WriteLine("Your Selection has been added to checkout");
      breadCart.Add(activeBread);
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
            Console.WriteLine($"    Bread Total: ${totalBreadCost.ToString()}.00");
          }

          if (pastryCart.Count != 0)
          {
            Console.WriteLine("Pastries");
            foreach (Pastry item in pastryCart)
            {
              Console.WriteLine($"    Type:{item.GetBakeType()} Amount:{item.GetAmount()} Cost:${item.GetCost().ToString()}.00");
              totalPastryCost += item.GetCost();
            }
            Console.WriteLine($"    Pastry Total: ${totalPastryCost.ToString()}.00");
          }
          Console.WriteLine("____________________");
          Console.WriteLine($"Total Order Cost: ${(totalBreadCost + totalPastryCost).ToString()}.00");
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
        if (acc[0] == "num") {
          if (Int32.Parse(tested) > 0)
          {
            return tested;
          }
        }
        else
        {
          foreach(string tester in acc)
          {
            if (tested == tester)
            {
              return tested;
            }
          }
        }
        Console.WriteLine(error);
        DrawChecker(20);
        callback();
        return "fail";
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        DrawChecker(20);
        callback();
        return "fail";
      }
    }
  }
}