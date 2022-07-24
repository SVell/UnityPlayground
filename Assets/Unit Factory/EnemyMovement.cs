using System;
using SVell.SecondOrderDynamics;
using UnityEngine;

namespace SVell.UnitFactory 
{
	public class EnemyMovement : MonoBehaviour
	{
		[SerializeField] private UpdateMode updateMode = UpdateMode.FixedUpdate;

		[Space]
        
		[Range(0.1f, 10)]
		[Tooltip("Frequency - speed in which system will response to the input")]
		[SerializeField] private float f = 1;

		[Range(0, 5)] [Tooltip("Damping coefficient - describes how system comes to settle")] 
		[SerializeField] private float z = 0.5f;

		[Range(-5, 5)] [Tooltip("Initial response")] 
		[SerializeField] private float r = 2;

		public Vector3 Destination { get; set; }

		public float Speed { get; set; } = 1f;

		private SecondOrderDynamics.SecondOrderDynamics _secondOrderDynamics;

		private void Awake()
		{
			_secondOrderDynamics = new SecondOrderDynamics.SecondOrderDynamics(f, z, r, transform.position);
		}

		private void Update()
		{
			if (updateMode == UpdateMode.Update) 
			{
				Compute(Time.deltaTime);
			}
		}

		private void LateUpdate()
		{
			if (updateMode == UpdateMode.LateUpdate) 
			{
				Compute(Time.deltaTime);
			} 
		}

		private void FixedUpdate()
		{
			if (updateMode == UpdateMode.FixedUpdate) 
			{
				Compute(Time.fixedDeltaTime);
			}
		}
		
		private void Compute(float T)
		{
			if (Destination != Vector3.zero)
			{
				transform.localPosition =
					_secondOrderDynamics.ComputePosition(T * Speed, Destination, Vector3.zero);
			}

			if (Vector3.Distance(transform.position, Destination) <= 0.001)
			{
				Destroy(gameObject, 1f);
			}
		}
	}
}
