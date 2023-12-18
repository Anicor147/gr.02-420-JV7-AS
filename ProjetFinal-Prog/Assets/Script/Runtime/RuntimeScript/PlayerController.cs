using System;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Runtime.RuntimeScript
{
    public class PlayerController : MonoBehaviour
    {
        private float _hpMax = 20f;
        private float _currentHp;
        public float CurrentHp
        {
            get => _currentHp;
             set => _currentHp = value;
        }
        internal static event Action<float> OnHpChange;
        internal static event Action OnDeath;



        private void Start()
        {
            PlayerMouvement.OnMovement += UpdateHp;
            _currentHp = _hpMax;
        }

        public void UpdateHp(float value)
        {
            _currentHp = Mathf.Clamp(_currentHp + value, 0, _hpMax);
            if (_currentHp == 0) Death();
            OnHpChange?.Invoke(value);
            //Debug.Log(_currentHp);
        }
        private void Death()
        {
            OnDeath?.Invoke();
        }

        private void OnDisable()
        {
            PlayerMouvement.OnMovement -= UpdateHp;
        }
    }
}
