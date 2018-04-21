using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntGameEvent : ScriptableObject {

    private List<IntGameEventListener> listeners = new List<IntGameEventListener>();
    public void Raise(int value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
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
