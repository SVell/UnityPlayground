using UnityEngine;

namespace Strategy 
{
	public class PlatformerMovement : IMovable
	{
		public Vector3 Move(float speed)
		{
			float x = Input.GetAxis("Horizontal");

			return new Vector3(0, 0, x) * speed * Time.deltaTime;
		}
	}
}
