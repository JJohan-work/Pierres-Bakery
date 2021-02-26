using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    [TestMethod]
    public void MenuItem_GetCostOfMenuItem_int()
    {
      int expectedCost = 0;
      MenuItem menuItem = new MenuItem();

      Assert.AreEqual(expectedCost, menuItem.GetCost());
    }
    public void MenuItem_GetAmountOfMenuItem_int()
    {
      int expectedAmount = 0;
      MenuItem menuItem = new MenuItem();

      Assert.AreEqual(expectedAmount, menuItem.GetAmount());
    }

    // [TestMethod]
    // public void Bread_CreateBreadObjectWithCostAndAmountSetToZero_int()
    // {
    //   Assert.AreEqual(expectedAmount, breadItem.getAmount());
    //   Assert.AreEqual(expectedCost, breadItem.getCost());
    // }
  }
}