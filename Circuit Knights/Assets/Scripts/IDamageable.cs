using UnityEngine;

namespace CircuitKnights
{
    public interface IDamageable
	{
		void TakeDamage(float damage);
		void Death();
	}
}