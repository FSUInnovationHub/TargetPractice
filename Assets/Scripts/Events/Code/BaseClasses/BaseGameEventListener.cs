using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, 
    IGameEventListener<T> where E: BaseGameEvent<T> where UER: UnityEvent<T>
{
    public E GameEvent;
    public UER Response;

    private void OnEnable()
    {
        this.GameEvent?.RegisterListener(this);
    }

    private void OnDisable()
    {
        this.GameEvent?.UnregisterListener(this);
    }

    public void OnEventRaised(T item)
    {
        this.Response?.Invoke(item);
    }
}
