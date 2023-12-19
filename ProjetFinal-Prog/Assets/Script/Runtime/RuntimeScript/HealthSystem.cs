using TMPro;
using UnityEngine;

namespace Script.Runtime.RuntimeScript
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _hpText;
        private float _currentPlayerHp;


        private void Awake()
        {
            PlayerController.OnHpChange += UpdateHpBar;
        }

        private void Start()
        {
            _currentPlayerHp = GameObject.FindWithTag("Player").GetComponent<PlayerController>().CurrentHp;
            _hpText.text = _currentPlayerHp.ToString();
        }

        private void OnDisable()
        {
            PlayerController.OnHpChange -= UpdateHpBar;
        }

        private void UpdateHpBar(float value)
        {
            if (value < 10)
            {
                _hpText.text = "0" + value;
            }
            else
            {
                _hpText.text = value.ToString();
            }
        }
    }
}
