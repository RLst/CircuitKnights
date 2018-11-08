using UnityEngine;

namespace CircuitKnights
{
    public interface IHealth
	{
		void TakeDamage(float damage);
		void Death();
	}
}