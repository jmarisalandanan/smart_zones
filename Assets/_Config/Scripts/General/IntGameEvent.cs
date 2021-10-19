using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntGameEvent : ScriptableObject
{
    private readonly List<IntGameEventListener> listeners = new List<IntGameEventListener>();

    public void Raise(int value)
    {
        for (var i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(IntGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(IntGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}