using UnityEngine;

namespace SVell.SecondOrderDynamics
{
    public class SecondOrderDynamicsTilt : SecondOrderDynamicsBase 
    {
        protected override void Compute(float t)
        {
            Vector3 pos = (followTarget.position - transform.position) * 20;
            Vector3 res = SecondOrderDynamics.ComputePosition(t, -pos, Vector3.zero);
            transform.localRotation = Quaternion.Euler(res.z, res.y, -res.x);
        }
    }
}
