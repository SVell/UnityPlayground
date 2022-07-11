using UnityEngine;

namespace SVell.SecondOrderDynamics
{
    public class SecondOrderDynamicsRotation : SecondOrderDynamicsBase
    {
        protected override void Compute(float t)
        {
            Vector3 res = SecondOrderDynamics.ComputePosition(t, followTarget.rotation.eulerAngles, Vector3.zero);
            
            Debug.Log(res);

            if (Mathf.Abs(res.y - transform.localRotation.eulerAngles.y) >= 10f)
            {
                SecondOrderDynamics.SetPosition(followTarget.rotation.eulerAngles);
                /*while (Mathf.Abs(followTarget.rotation.eulerAngles.y - transform.localRotation.eulerAngles.y) >= 1)
                {
                    transform.localRotation = Quaternion.Euler(SecondOrderDynamics.ComputePosition(t, followTarget.rotation.eulerAngles, Vector3.zero));
                }*/
            }
            
            res = SecondOrderDynamics.ComputePosition(t, followTarget.rotation.eulerAngles, Vector3.zero);
            transform.localRotation = Quaternion.Euler(res);
        }
    }
}
