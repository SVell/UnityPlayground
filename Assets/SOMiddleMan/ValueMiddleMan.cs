using UnityEngine;

namespace SVell.ValueMiddleMan
{
    [CreateAssetMenu]
    public class ValueMiddleMan : ScriptableObject
    {
        [SerializeField] private GameEvent OnValueChangedEvent;
        
        private int _value;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChangedEvent.Raise();
            }
        }
    }
}

