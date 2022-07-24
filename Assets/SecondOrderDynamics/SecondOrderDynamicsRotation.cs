using UnityEngine;

namespace SVell.SecondOrderDynamics
{
    public class SecondOrderDynamicsRotation : SecondOrderDynamicsBase
    {
        [SerializeField] private float speed;
        protected override void Compute(float t)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, followTarget.rotation, speed * t);
        }
    }
}
