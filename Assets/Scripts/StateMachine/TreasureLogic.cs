using UnityEngine;

public class TreasureLogic : MonoBehaviour
{
	[SerializeField] private float m_minSpawnDelay = 1.0f;
	[SerializeField] private float m_maxSpawnDelay = 5.0f;

	[SerializeField] private float m_randomSpawnRange = 25.0f;

	[SerializeField] private GameObject m_treasure;

	private float m_spawnDelay;
	private float m_timer;
	private bool m_treasureIsActive;

	private void Start()
	{
		m_spawnDelay = Random.Range(m_minSpawnDelay, m_maxSpawnDelay);

		var pointInCircle = Random.insideUnitCircle * m_randomSpawnRange;
		m_treasure.transform.position = new Vector3(pointInCircle.x, 0.25f, pointInCircle.y);
	}

	private void Update()
	{
		if (m_timer > m_spawnDelay && !m_treasure.gameObject.activeInHierarchy)
		{
			m_timer = 0.0f;

			var pointInCircle = Random.insideUnitCircle * m_randomSpawnRange;
			m_treasure.SetActive(true);
			m_treasure.transform.position = new Vector3(pointInCircle.x, 0.25f, pointInCircle.y);

			m_spawnDelay = Random.Range(m_minSpawnDelay, m_maxSpawnDelay);
		}

		if (!m_treasure.gameObject.activeInHierarchy)
		{
			m_timer += Time.deltaTime;
		}
	}
}