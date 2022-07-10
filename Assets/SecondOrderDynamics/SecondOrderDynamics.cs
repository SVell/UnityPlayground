using System;
using UnityEngine;

namespace SVell.Movement
{
    public enum UpdateMode
    {
        Update,
        FixedUpdate,
        LateUpdate
    }
    public class SecondOrderDynamics : MonoBehaviour
    {
        [SerializeField] private UpdateMode updateMode;

        [Space] 
        [Range(0, 10)]
        [SerializeField] private float f = 5;
        [Range(0,5)]
        [SerializeField] private float z = 1;
        [Range(-1, 1)]
        [SerializeField] private float r = 0;

        [SerializeField] private Transform followTarget;

        private Vector3 _xp;
        private Vector3 _y, _yd;
        private float _w, _z, _d, _k1, _k2, _k3;

        private void Update()
        {
            if (updateMode == UpdateMode.Update)
            {
                transform.position = ComputePosition(Time.deltaTime, followTarget.position, Vector3.zero);
            }
        }

        private void FixedUpdate()
        {
            if (updateMode == UpdateMode.FixedUpdate)
            {
                transform.position = ComputePosition(Time.fixedDeltaTime, followTarget.position, Vector3.zero);
            }
        }

        private void LateUpdate()
        {
            if (updateMode == UpdateMode.LateUpdate)
            {
                transform.position = ComputePosition(Time.deltaTime, followTarget.position, Vector3.zero);
            }
        }

        private void UpdateValues()
        {
            _w = 2 * Mathf.PI * f;
            _z = z;
            _d = _w * Mathf.Sqrt(Mathf.Abs(z * z - 1));
            _k1 = z / (Mathf.PI * f);
            _k2 = 1 / (_w * _w);
            _k3 = r * z / _w;

            _xp = followTarget.position;
            _y = _xp;
            _yd = _xp;
        }

        private Vector3 ComputePosition(float T, Vector3 x, Vector3 xd)
        {
            if (xd == Vector3.zero)
            {
                xd = (x - _xp) / T;
                _xp = x;
            }

            float k1Stable;
            float k2Stable;

            if (_w * T < _z)
            {
                k1Stable = _k1;
                k2Stable = Mathf.Max(_k2, T * T / 2 + T * _k1 / 2, T * _k1);
            }
            else
            {
                float t1 = Mathf.Exp(-_z * _w * T);
                float alpha = 2 * t1 * (_z <= 1 ? Mathf.Cos(T * _d) : MathF.Cosh(T * _d));
                float beta = t1 * t1;
                float t2 = T / (1 + beta - alpha);
                k1Stable = (1 - beta) * t2;
                k2Stable = T * t2;
            }

            _y += + T * _yd;
            _yd += T * (x + _k3 * xd - _y - k1Stable * _yd) / k2Stable;

            return _y;
        }

        private void OnValidate()
        {
            UpdateValues();
        }
    }
}
