using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class MenuItem
  {
    protected int _amount;
    protected string _type;
    public int GetAmount()
    {
      return _amount;
    }

    public void AddAmount(int toAdd)
    {
      _amount = _amount + toAdd;
    }

    public void RemoveAmount(int toAdd)
    {
      if (_amount - toAdd >= 0)
      {
        _amount = _amount - toAdd;
      }
      else
      {
        _amount = 0;
      }
    }
    public void SetBakeType(string type)
    {

    }
    public string GetBakeType()
    {
      return "test";
    }
  }

  public class Bread : MenuItem
  {
    public int GetCost()
    {
      int specials = this._amount / 3;
      int regular = this._amount % 3;

      return ((specials * 10) + (regular * 5));
    }
  }
  public class Pastry : MenuItem
  {
    public int GetCost()
    {
      int specials = this._amount / 3;
      int regular = this._amount % 3;

      return ((specials * 5) + (regular * 2));
    }
  }
}