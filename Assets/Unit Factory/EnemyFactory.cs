using UnityEngine;

namespace SVell.UnitFactory 
{
	public abstract class EnemyFactory : ScriptableObject
	{
		public Enemy GetEnemy(EnemyType type)
		{
			var config = GetConfig(type);
			var enemy = SpawnEnemy(config);
			return enemy;
		}

		protected abstract EnemyConfig GetConfig(EnemyType type);

		private Enemy SpawnEnemy(EnemyConfig config)
		{
			Enemy enemy = Instantiate(config.Prefab);
			enemy.Init(config.Health, config.Speed, config.WanderRadius);

			return enemy;
		}
	}
}
