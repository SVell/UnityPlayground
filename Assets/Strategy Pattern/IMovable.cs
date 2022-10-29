using UnityEngine;

namespace Strategy
{
	public interface IMovable
	{
		public Vector3 Move(float speed);
	}
}
