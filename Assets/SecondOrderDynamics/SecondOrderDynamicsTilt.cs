using UnityEngine;

namespace SVell.SecondOrderDynamics
{
    public class SecondOrderDynamicsTilt : SecondOrderDynamicsBase
    {
        [SerializeField] private float tiltStrength = 20f;
        protected override void Compute(float t)
        {
            Vector3 pos = (followTarget.position - transform.position) * tiltStrength;
            Vector3 res = SecondOrderDynamics.ComputePosition(t, -pos, Vector3.zero);
            transform.localRotation = Quaternion.Euler(res.z, res.y, -res.x);
        }
    }
}
