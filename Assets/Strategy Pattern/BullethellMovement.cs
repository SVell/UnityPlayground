using UnityEngine;

namespace Strategy
{
	public class BullethellMovement: IMovable
	{
		public Vector3 Move(float speed)
		{
			float x = Input.GetAxis("Horizontal");
			float y = Input.GetAxis("Vertical");

			return new Vector3(0, y, x).normalized * speed * Time.deltaTime;
		}
	}
}
