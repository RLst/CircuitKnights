using UnityEngine;
using CircuitKnights.Events;

namespace CircuitKnights
{
    public class TrackEndTrigger : MonoBehaviour
    {
        [SerializeField] GameEvent onReachedEndOfTrack;

        void OnTriggerEnter(Collider collider)
        {
            //If a player has hit this track end collider (in this case just use the torso collider)
            if (collider == GameSettings.Instance.PlayerOne.TorsoCollider ||
                collider == GameSettings.Instance.PlayerTwo.TorsoCollider)
            {
                onReachedEndOfTrack.Raise();
            }
        }
    }

}