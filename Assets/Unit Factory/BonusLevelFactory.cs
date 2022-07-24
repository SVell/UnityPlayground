using UnityEngine;

namespace SVell.UnitFactory 
{
	[CreateAssetMenu]
	public class BonusLevelFactory : EnemyFactory
	{
		[SerializeField] private EnemyConfig bonusSkeleton;
		[SerializeField] private EnemyConfig bonusZombie;
		[SerializeField] private EnemyConfig bonusElemental;
		
		protected override EnemyConfig GetConfig(EnemyType type)
		{
			switch (type)
			{
				case EnemyType.Skeleton:
					return bonusSkeleton;
				case EnemyType.Zombie:
					return bonusZombie;
				case EnemyType.Elemental:
					return bonusElemental;
				default:
					Debug.LogError($"No config for: {type}");
					return bonusSkeleton;
			}
		}
	}
}
