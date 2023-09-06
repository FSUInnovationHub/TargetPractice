using System;
using UnityEngine.Events;

// This is used to provide a response to the event in the EventListener
// When you add the event listener component this allows you to add a function
// This is used for void events
namespace Assets.Scripts.Events
{
    [Serializable] public class UnityEventVoid : UnityEvent<Void>
    {
    }

    [Serializable] public struct Void { };
}
