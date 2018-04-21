using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class IntGameEventListener : MonoBehaviour {

    public IntGameEvent gameEvent;
    public IntEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }
    private void OnDisable()
    {
        gameEvent.UnRegisterListener(this);
    }

    public void OnEventRaised(int value)
    {
        response.Invoke(value);
    }
}
