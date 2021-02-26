using System;

namespace Bakery.Models
{
  public class MenuItem
  {
    private int _cost = 0;
    private int _amount = 0;

    public int GetCost()
    {
      return _cost;
    }
    public int GetAmount()
    {
      return _amount;
    }
  }

  public class Bread : MenuItem
  {

  }
  public class Pastry : MenuItem
  {

  }
}