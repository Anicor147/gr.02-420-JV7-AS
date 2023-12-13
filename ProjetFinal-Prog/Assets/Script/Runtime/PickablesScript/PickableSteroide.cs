using Script.Runtime.RuntimeScript;
using Script.Runtime.ScriptableObjectScript;
using UnityEngine;

namespace Script.Runtime.PickablesScript
{
    public class PickableSteroide : MonoBehaviour
    {
        [SerializeField] private float _increaseMaxHp;
        private SoChickenDataScript _soChickenDataScript;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            other.GetComponent<PlayerController>().IncreaseMaxHp(_increaseMaxHp);
            Destroy(gameObject);
        }
    }
}
