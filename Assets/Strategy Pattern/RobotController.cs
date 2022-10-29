using UnityEngine;

namespace Strategy
{
	public class RobotController : MonoBehaviour
	{
		[SerializeField] private float speed;

		private IMovable _movable;

		private void Awake()
		{
			_movable = new PlatformerMovement();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Debug.Log("Strategy Changed");
				if (_movable is PlatformerMovement)
				{
					_movable = new BullethellMovement();
				}
				else
				{
					_movable = new PlatformerMovement();
				}
			}

			transform.Translate(_movable.Move(speed));
		}
	}
}
