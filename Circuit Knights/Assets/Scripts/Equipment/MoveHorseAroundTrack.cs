using UnityEngine;

namespace CircuitKnights
{
    public class MoveHorseAroundTrack : MonoBehaviour
    {
        Horse horse;

		void Awake()
		{
            horse = GetComponent<Horse>();
        }
        
    }
}