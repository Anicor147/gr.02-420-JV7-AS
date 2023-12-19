using UnityEngine;

namespace Script.Runtime.RuntimeScript
{
    public class CameraMovement : MonoBehaviour
    {
        private Camera _camera;
        private GameObject _player;

        private void Awake()
        {
            _camera = Camera.main;
            _player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            _camera.transform.position = _player.transform.position + new Vector3(0f, 0f, -8f);
        }
    }
}
