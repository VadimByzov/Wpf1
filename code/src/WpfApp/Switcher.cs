using System;
using System.Collections.Generic;

namespace WpfApp;

public static class Switcher
{
  private static readonly Dictionary<string, Action<int>> switcher = new();

  private static readonly Stack<string> history = new();

  public static void Register(string viewmodelName, Action<int> callback)
  {
    if (!switcher.ContainsKey(viewmodelName))
      switcher.Add(viewmodelName, callback);
  }

  public static void Unregister(string viewmodelName)
  {
    if (switcher.ContainsKey(viewmodelName))
      switcher.Remove(viewmodelName);
  }

  public static void Switch(string viewmodelName, string fromName, int id)
  {
    if (switcher.ContainsKey(viewmodelName))
    {
      switcher[viewmodelName].Invoke(id);
      history.Push(fromName);
    }
  }

  public static void Back(int id)
  {
    switcher[history.Pop()].Invoke(id);
  }
}