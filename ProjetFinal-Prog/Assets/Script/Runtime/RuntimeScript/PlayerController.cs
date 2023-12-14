using System;
using UnityEngine;

namespace Script.Runtime.RuntimeScript
{
    public class PlayerController : MonoBehaviour
    {
        private float _hpMax;
        private float _currentHp;

        public static event Action<float> OnHpChange;

        public void UpdateHp(float value)
        {
            _currentHp += value;
            OnHpChange?.Invoke(_currentHp);
        }

        public void IncreaseMaxHp(float value)
        {
            _hpMax = value;
        }
    }
}
