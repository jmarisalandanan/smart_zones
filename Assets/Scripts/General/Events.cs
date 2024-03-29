﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace Magicspace.SmartZones
{
    [Serializable]
    public class FloatEvent : UnityEvent<float>
    {
    }

    [Serializable]
    public class BoolEvent : UnityEvent<bool>
    {
    }

    [Serializable]
    public class IntEvent : UnityEvent<int>
    {
    }

    [Serializable]
    public class VectorEvent : UnityEvent<Vector2>
    {
    }

    [Serializable]
    public class RoleEvent : UnityEvent<Role>
    {
    }
}
