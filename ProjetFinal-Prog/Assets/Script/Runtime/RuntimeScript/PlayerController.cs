using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Runtime.RuntimeScript
{
    public class PlayerController : MonoBehaviour
    {
        private float _hpMax;
        private float _currentHp = 10f;


        private void Start()
        {
            PlayerMouvement.OnMovement += UpdateHp;
        }

        public static event Action<float> OnHpChange;

        public void UpdateHp(float value)
        {

            _currentHp = Mathf.Clamp(_currentHp + value, 0, _hpMax);
            if (_currentHp == 0) Death();
            //add UI update line

        }


        public void IncreaseMaxHp(float value)
        {
            _hpMax += value;
            //add UI update line
        }
        private void Death()
        {
            
        }
    }
}
