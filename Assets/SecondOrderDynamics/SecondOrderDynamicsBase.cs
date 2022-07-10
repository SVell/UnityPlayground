using UnityEngine;

namespace SVell.SecondOrderDynamics
{
    public abstract class SecondOrderDynamicsBase : MonoBehaviour
    {
        [SerializeField] private UpdateMode updateMode = UpdateMode.FixedUpdate;

        [Space]
        
        [Range(0, 10)]
        [Tooltip("Frequency - speed in which system will response to the input")]
        [SerializeField]
        private float f = 1;

        [Range(0, 5)] [Tooltip("Damping coefficient - describes how system comes to settle")] [SerializeField]
        private float z = 0.5f;

        [Range(-5, 5)] [Tooltip("Initial response")] [SerializeField]
        private float r = 2;

        [SerializeField] protected Transform followTarget;

        protected SecondOrderDynamics SecondOrderDynamics;

        private void Start()
        {
            SecondOrderDynamics = new SecondOrderDynamics(f, z, r, followTarget.position);
        }

        private void Update()
        {
            if (updateMode == UpdateMode.Update) 
            {
                Compute(Time.deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (updateMode == UpdateMode.LateUpdate) 
            {
                Compute(Time.deltaTime);
            } 
        }

        private void FixedUpdate()
        {
            if (updateMode == UpdateMode.FixedUpdate) 
            {
                Compute(Time.fixedDeltaTime);
            }
        }

        protected abstract void Compute(float T);
    }
}
