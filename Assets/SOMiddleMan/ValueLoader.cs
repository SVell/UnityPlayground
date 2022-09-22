using UnityEngine;

namespace SVell.ValueMiddleMan
{
    public class ValueLoader : MonoBehaviour
    {
        [SerializeField] private ValueMiddleMan valueMiddleMan;

        private void Awake()
        {
            valueMiddleMan.Value = 228;
        }
    }
}

