using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private int m_healthPoint = 30;

	public bool TakeHit(int power)
	{
		Debug.Log($"Current enemy heal is {m_healthPoint}");
		m_healthPoint -= power;

		bool isDead = m_healthPoint <= 0;
		if (isDead)
		{
			Die();
		}

		return isDead;
	}

	private void Die()
	{
		gameObject.SetActive(false);
	}
}
