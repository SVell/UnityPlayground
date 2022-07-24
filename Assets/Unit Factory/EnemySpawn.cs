using UnityEngine;

namespace SVell.UnitFactory 
{
	public class EnemySpawn : MonoBehaviour
	{
		[SerializeField] private EnemyFactory enemyFactory;

		[SerializeField] private float spawnOffset = 5f;

		private float _spawnTimer;

		private void Update()
		{
			_spawnTimer += Time.deltaTime;

			if (_spawnTimer >= spawnOffset)
			{
				_spawnTimer = 0;

				SpawnEnemy();
			}
		}

		private void SpawnEnemy()
		{
			Enemy enemy = enemyFactory.GetEnemy((EnemyType)Random.Range(0, 3));

			enemy.transform.position = transform.position;
		}
	}
}
