using UnityEngine;

namespace CircuitKnights
{
    public abstract class Damageable : MonoBehaviour
	{
		float health;
		public virtual void TakeDamage(float damage)
		{
			health -= damage;
			if (health <= 0)
				Death();
		}
		public virtual void Death()
		{
			Debug.Log("Dead");
		}
	}
}