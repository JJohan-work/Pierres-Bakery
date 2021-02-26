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
      Console.WriteLine("Welcome to Pierres Bakery!");
      InitialPrompt();
    }

    public static void InitialPrompt()
    {
      Console.Write("Please select an option: (bread/pastry/checkout/exit): ");
      string response = Console.ReadLine();
      
      if (response.ToLower() == "bread")
      {
        Bread breadItem = new Bread();
        Console.Write("How many loafs would you like to buy?: ");
        int amountToAdd = Int32.Parse(Console.ReadLine());
        breadItem.AddAmount(amountToAdd);
        breadCart.Add(breadItem);
        InitialPrompt();
      }
      // else if (response.ToLower() == "pastry")
      // {
      //   Pastry pastryCart = new Pastry();
      //   Console.Write("How many pastries would you like to buy?: ");
      //   int amountToAdd = Int32.Parse(Console.ReadLine());
      //   pastryCart.AddAmount(amountToAdd);
      //   InitialPrompt();
      // }
      else if (response.ToLower() == "checkout")
      {
        if (breadCart.Count == 0 && pastryCart.Count == 0)
        {
          Console.WriteLine("Order at least 1 item from shop before checking out");
          InitialPrompt();
        }
        else
        {
          foreach (Bread item in breadCart)
          {
            Console.WriteLine($"{item.GetCost().ToString()}");
          }

          // Console.WriteLine($"Your Total is: ${breadCart.GetCost() + pastryCart.GetCost()}");
          Console.WriteLine("Thank you for Shopping at Pierre's Bakery! Have a good day!");
        }
      }
      else if (response.ToLower() == "exit")
      {
        Console.WriteLine("GoodBye!");
      }
    }
  }
}