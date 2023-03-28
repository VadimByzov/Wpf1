using System;
using System.Collections.Generic;

namespace WpfApp;

public static class Switcher
{
  private static readonly Dictionary<string, Action<int>> switcher = new();

  private static readonly Stack<KeyValuePair<string, int>> history = new();

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

  public static void Switch(string viewmodelName, string fromName, int id, int fromId)
  {
    if (switcher.ContainsKey(viewmodelName))
    {
      switcher[viewmodelName].Invoke(id);
      history.Push(new(fromName, fromId));
    }
  }

  public static void Back()
  {
    (var viewmodel, var parentId) = history.Pop();
    switcher[viewmodel].Invoke(parentId);
  }
}