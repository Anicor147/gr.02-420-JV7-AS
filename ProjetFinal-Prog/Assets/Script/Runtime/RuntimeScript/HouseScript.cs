using UnityEngine;

namespace Script.Runtime.RuntimeScript
{
    public class HouseScript : MonoBehaviour
    {
        private GameObject _winnigCanvas;

        private void Start()
        {
            _winnigCanvas = GameObject.FindGameObjectWithTag("WinnigScreen");
            _winnigCanvas.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            _winnigCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
