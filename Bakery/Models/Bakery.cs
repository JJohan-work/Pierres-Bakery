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

    public void AddAmount(int toAdd)
    {
      _amount += toAdd;
    }

    public void RemoveAmount(int toAdd)
    {
      if (_amount - toAdd >= 0)
      {
        _amount -= toAdd;
      }
      else
      {
        _amount = 0;
      }
    }
  }

  public class Bread : MenuItem
  {
    public int GetCost()
    {
      return 5;
    }
  }
  public class Pastry : MenuItem
  {

  }
}