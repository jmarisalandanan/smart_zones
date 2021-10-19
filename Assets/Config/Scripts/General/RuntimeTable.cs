using System.Collections.Generic;
using UnityEngine;

public interface IRuntimeTable<TKey, TValue>
{
    TValue this[TKey key] { get; set; }
}

public abstract class RuntimeTable<TKey, TValue> : ScriptableObject, IRuntimeTable<TKey, TValue>
{
    public Dictionary<TKey, TValue> KeyPair = new Dictionary<TKey, TValue>();

    public TValue this[TKey key]
    {
        get => KeyPair[key];
        set => KeyPair[key] = value;
    }

    public void Add(TKey key, TValue value)
    {
        if (!KeyPair.ContainsKey(key)) KeyPair.Add(key, value);
    }

    public void Remove(TKey key)
    {
        if (KeyPair.ContainsKey(key)) KeyPair.Remove(key);
    }
}