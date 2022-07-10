using UnityEngine;

namespace SVell.SecondOrderDynamics
{
    public class SecondOrderDynamicsMovement : SecondOrderDynamicsBase
    {
        protected override void Compute(float t)
        {
            transform.localPosition =
                SecondOrderDynamics.ComputePosition(t, followTarget.position, Vector3.zero);
        }
    }
}
