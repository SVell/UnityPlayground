using System;

namespace SVell.UnitFactory
{
	[Serializable]
	public class EnemyConfig
	{
		public Enemy Prefab;
		public float Speed;
		public float Health;
		public float WanderRadius = 5f;
	}
}
