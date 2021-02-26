using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class MenuItemTests
  {

    [TestMethod]
    public void MenuItem_GetAmountOfMenuItem_int()
    {
      int expectedAmount = 0;
      MenuItem menuItem = new MenuItem();

      Assert.AreEqual(expectedAmount, menuItem.GetAmount());
    }

    [TestMethod]
    public void MenuItem_AddGivenAmountToAmount_void()
    {
      int expectednewAmount = 2;
      MenuItem menuItem = new MenuItem();

      menuItem.AddAmount(2);

      Assert.AreEqual(expectednewAmount, menuItem.GetAmount());
    }

    [TestMethod]
    public void MenuItem_RemoveGivenAmountToAmount_void()
    {
      int expectednewAmount = 1;
      MenuItem menuItem = new MenuItem();

      menuItem.AddAmount(2);
      menuItem.RemoveAmount(1);

      Assert.AreEqual(expectednewAmount, menuItem.GetAmount());
    }
  }
  [TestClass]
  public class BreadTests
  {
    [TestMethod]
    public void Bread_CalculateCostOfBread_int()
    {
      int expectedCost = 45;
      int givenAmount = 13;

      Bread bread = new Bread();
      bread.AddAmount(givenAmount);
      
      int outputedCost = bread.GetCost();

      Assert.AreEqual(expectedCost, outputedCost);
    }
  }
  [TestClass]
  public class PastryTests
  {
    [TestMethod]
    public void Pastry_CalculateCostOfPastry_int()
    {
      int expectedCost = 14;
      int givenAmount = 8;

      Pastry pastry = new Pastry();
      pastry.AddAmount(givenAmount);
      
      int outputedCost = pastry.GetCost();

      Assert.AreEqual(expectedCost, outputedCost);
    }
  }
}