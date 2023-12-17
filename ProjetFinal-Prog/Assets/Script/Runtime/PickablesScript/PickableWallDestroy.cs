using Script.Runtime.RuntimeScript;
using UnityEngine;

namespace Script.Runtime.PickablesScript
{
    public class PickableWallDestroy : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (other.GetComponent<DestroyWall>().ChargeIsMaxed) return;
            other.GetComponent<DestroyWall>().UpdateCharges();
            Destroy(gameObject);
        }
    }
}
