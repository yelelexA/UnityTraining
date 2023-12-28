public interface IDamageable
{
	float maxHealth { get; set; }
	float currentHealth { get; set; }

	void Damage(float damageAmount);
	void Die();
}