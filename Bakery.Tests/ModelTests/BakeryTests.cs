using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    [TestMethod]
    public void Bread_CreateBreadObjectWithCostAndAmountSetToZero_int()
    {
      int expectedCost = 0;
      int expectedAmount = 0;
      Bread breadItem = new Bread();

      Assert.AreEqual(expectedAmount, breadItem.amount);
      Assert.AreEqual(expectedCost, breadItem.cost);
    }
  }
}