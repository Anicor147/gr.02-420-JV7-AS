using Script.Runtime.RuntimeScript;
using Script.Runtime.ScriptableObjectScript;
using UnityEngine;

namespace Script.Runtime.PickablesScript
{
    public class PickableChicken : MonoBehaviour
    {
        [SerializeField] private SoChickenDataScript _soChickenDataScript;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            other.GetComponent<PlayerController>().UpdateHp(_soChickenDataScript.RecoverHealth);
            Destroy(gameObject);
        }
    }
}
