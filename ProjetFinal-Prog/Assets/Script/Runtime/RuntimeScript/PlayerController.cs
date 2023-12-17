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

        public void UpdateHp(float value)
        {
            _currentHp += value;
            print(_currentHp);
        }

        public void IncreaseMaxHp(float value)
        {
            _hpMax = value;
        }
    }
}
