using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class MenuItemTests
  {
    [TestMethod]
    public void MenuItem_GetCostOfMenuItem_int()
    {
      int expectedCost = 0;
      MenuItem menuItem = new MenuItem();
      Assert.AreEqual(expectedCost, menuItem.GetCost());
    }

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


    // [TestMethod]
    // public void Bread_CreateBreadObjectWithCostAndAmountSetToZero_int()
    // {
    //   Assert.AreEqual(expectedAmount, breadItem.getAmount());
    //   Assert.AreEqual(expectedCost, breadItem.getCost());
    // }
  }
}