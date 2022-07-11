using System;
using UnityEditor.UIElements;
using UnityEngine;

namespace SVell.SecondOrderDynamics
{
    public class LegMover : MonoBehaviour
    {
        [SerializeField] private float stepDistance;
        [SerializeField] private float stepHeight;
        [SerializeField] private float speed;
        [SerializeField] private LayerMask whatIsGround;

        [SerializeField] private LegMover otherFoot;
        
        [SerializeField] private Vector3 footOffset;

        [SerializeField] private Transform raycastPos;

        private Vector3 _currentPosition;
        private Vector3 _newPosition;
        private Vector3 _oldPosition;

        private float _lerp = 1;

        private void Start()
        {
            _currentPosition = _newPosition = _oldPosition = transform.position;
            footOffset.y = transform.position.y;
        }

        private void Update()
        {
            transform.position = _currentPosition;
            
            Ray ray = new Ray(raycastPos.position, Vector3.down);
            if (Physics.Raycast(ray, out var info, whatIsGround))
            {
                if (Vector3.Distance(_newPosition, info.point) > stepDistance  && !otherFoot.IsMoving() && _lerp >= 1)
                {
                    _lerp = 0;
                    _newPosition = info.point;
                }
            }

            if (_lerp < 1)
            {
                Vector3 footPosition = Vector3.Lerp(_oldPosition, _newPosition, _lerp);
                footPosition.y += Mathf.Sin(_lerp * Mathf.PI) * stepHeight + footOffset.y;

                _currentPosition = footPosition;
                _lerp += Time.deltaTime * speed;
            }
            else
            {
                _oldPosition = _newPosition;
            }
        }

        public bool IsMoving()
        {
            return _lerp < 1;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_newPosition, 0.2f);
        }
    }
}
