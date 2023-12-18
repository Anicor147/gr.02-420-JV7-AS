using System;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Runtime.RuntimeScript
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject _losingScreen;
        private float _hpMax = 20f;
        private float _currentHp = 20f;
        public float CurrentHp
        {
            get => _currentHp;
             set => _currentHp = value;
        }
        internal static event Action<float> OnHpChange;
        internal static event Action OnSteroidTake;



        private void Start()
        {
            PlayerMouvement.OnMovement += UpdateHp;
        }

        public void UpdateHp(float value)
        {
            _currentHp = Mathf.Clamp(_currentHp + value, 0, _hpMax);
            //if (_currentHp == 0) Death();
            OnHpChange?.Invoke(value);
            Debug.Log(_currentHp.ToString());
        }


        public void IncreaseMaxHp(float value)
        {
            _hpMax += value;
            OnSteroidTake?.Invoke();
        }
        private void Death()
        {
            Destroy(gameObject);
            //add GameOverState line
        }

        private void OnDisable()
        {
            PlayerMouvement.OnMovement -= UpdateHp;
        }
    }
}
