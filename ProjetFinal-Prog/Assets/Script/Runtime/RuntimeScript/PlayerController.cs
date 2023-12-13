using UnityEngine;

namespace Script.Runtime.RuntimeScript
{
    public class PlayerController : MonoBehaviour
    {
        private float _hpMax;
        private float _currentHp;


        public void UpdateHp(float value)
        {
            _currentHp += value;
        }
    }
}
