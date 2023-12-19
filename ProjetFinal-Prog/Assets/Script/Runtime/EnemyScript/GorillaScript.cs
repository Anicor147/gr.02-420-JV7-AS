using Script.Runtime.RuntimeScript;
using UnityEngine;

namespace Script.Runtime.EnemyScript
{
    public class GorillaScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            other.gameObject.GetComponent<PlayerController>().UpdateHp(-20);
            Destroy(gameObject);
        }
    }
}
