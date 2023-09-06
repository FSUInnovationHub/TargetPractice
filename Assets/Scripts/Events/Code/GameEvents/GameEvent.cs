using UnityEngine;

// This Raises a void event, to create one, right click in project solution
// and select Create Game Event
namespace Assets.Scripts.Events
{
    [CreateAssetMenu (menuName="CreateEvents/GameEvent")]
    public class GameEvent : BaseGameEvent<Void>
    {
        public void Raise()
        {
            this.Raise(new Void());
        }
    }
}
