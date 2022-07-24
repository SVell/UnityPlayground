using UnityEngine;
using Random = UnityEngine.Random;

namespace SVell.UnitFactory
{
	[RequireComponent(typeof(EnemyMovement))]
	public class Enemy : MonoBehaviour
	{

		private EnemyMovement _enemyMovement;
		
		private float _health;
		private float _speed;
		private float _wanderRadius;

		private void Awake()
		{
			_enemyMovement = GetComponent<EnemyMovement>();
		}

		private void Start()
		{
			var tempVector = Random.insideUnitCircle * _wanderRadius;
			_enemyMovement.Destination = new Vector3(tempVector.x, transform.position.y, tempVector.y);
			_enemyMovement.Speed = _speed;
		}

		public void Init(float health, float speed, float wanderRadius)
		{
			_health = health;
			_speed = speed;
			_wanderRadius = wanderRadius;
		}
	}
}
