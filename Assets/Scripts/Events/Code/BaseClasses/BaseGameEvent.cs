using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameEvent<T> : ScriptableObject
{
    private List<IGameEventListener<T>> listeners = new List<IGameEventListener<T>>();

    public void Raise(T item)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            try
            {
                listeners[i].OnEventRaised(item);
            }
            catch (Exception e)
            {
                Debug.LogError($"An exception was thrown while trying to fire a event from {listeners[i]}: " + e.Message);
            }
        }
    }

    public void RegisterListener(IGameEventListener<T> listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(IGameEventListener<T> listener)
    {
        listeners.Remove(listener);
    }
}
