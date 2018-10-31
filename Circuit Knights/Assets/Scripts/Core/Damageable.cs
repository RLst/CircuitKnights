using System;

public abstract class Damageable
{
	float health;

	public void TakeDamage(float damageAmount)
	{
		health -= damageAmount;
		if (health <= 0)
			Kill();
	}

    private void Kill()
    {
        throw new NotImplementedException();
    }
}
