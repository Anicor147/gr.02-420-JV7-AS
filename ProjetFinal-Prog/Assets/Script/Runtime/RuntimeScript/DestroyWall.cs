using System;
using UnityEngine;

namespace Script.Runtime.RuntimeScript
{
    public class DestroyWall : MonoBehaviour
    {
        private int _numberOfCharge;
        private const int _numberOfMaxCharge = 3;
        public bool IsMaxed { get; private set; }

        public void UpdateCharges()
        {
            _numberOfCharge = Math.Min(_numberOfCharge + 1, _numberOfMaxCharge);
            IsMaxed = _numberOfCharge == _numberOfMaxCharge;
        }
    }
}
