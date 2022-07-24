using UnityEngine;

namespace SVell.UnitFactory 
{
	[CreateAssetMenu]
	public class GeneralEnemyFactory : EnemyFactory
	{
		[SerializeField] private EnemyConfig skeleton;
		[SerializeField] private EnemyConfig zombie;
		[SerializeField] private EnemyConfig elemental;
		
		protected override EnemyConfig GetConfig(EnemyType type)
		{
			switch (type)
			{
				case EnemyType.Skeleton:
					return skeleton;
				case EnemyType.Zombie:
					return zombie;
				case EnemyType.Elemental:
					return elemental;
				default:
					Debug.LogError($"No config for: {type}");
					return skeleton;
			}
		}
	}
}
