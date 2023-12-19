using TMPro;
using UnityEngine;

namespace Script.Runtime.RuntimeScript
{
    public class ChargeSystem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _chargeText;
        private int _numberOfCharges = 3;

        private void Start()
        {
            _chargeText.text = _numberOfCharges.ToString();
            DestroyWall.OnChargeUpdate += ChargeUpdate;
        }

        public void ChargeUpdate(int obj)
        {
            _chargeText.text = obj.ToString();
        }
    }
}
