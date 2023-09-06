using UnityEngine;

// This Raises an event that can pass a GameObject as a parameter, to create one, 
// right click in project solution and select Create Game Event Game Object
namespace Assets.Scripts.Events
{
    [CreateAssetMenu(menuName = "CreateEvents/GameEventBool")]
    public class GameEventBool : BaseGameEvent<bool> { }
}
