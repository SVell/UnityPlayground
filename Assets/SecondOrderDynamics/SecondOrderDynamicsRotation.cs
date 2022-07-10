using UnityEngine;

namespace SVell.SecondOrderDynamics
{
    public class SecondOrderDynamicsRotation : SecondOrderDynamicsBase 
    {
        protected override void Compute(float t)
        {
            transform.localRotation =
                Quaternion.Euler(SecondOrderDynamics.ComputePosition(t,
                    SecondOrderDynamics.GetSignedEulerAngles(followTarget.rotation.eulerAngles),
                    Vector3.zero));
        }
    }
}
