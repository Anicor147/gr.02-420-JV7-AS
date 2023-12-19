using System;
using System.Numerics;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Script.Runtime.RuntimeScript
{
    public class PlayerMouvement : MonoBehaviour
    {
        private Tilemap _tilemap;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _newPosition;
        internal static event Action<float> OnMovement;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _tilemap = GameObject.FindWithTag("tilemap").GetComponent<Tilemap>();
            CenterPlayer();
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            _newPosition = Vector2.zero;

            if (Input.GetKeyDown(KeyCode.D)) _newPosition = Vector2.right;
            else if (Input.GetKeyDown(KeyCode.A)) _newPosition = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.S)) _newPosition = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.W)) _newPosition = Vector2.up;

            if (_newPosition == Vector2.zero) return;
            FlipSprite(_newPosition);
            _rigidbody2D.MovePosition(_rigidbody2D.position + _newPosition);
            OnMovement?.Invoke(-2f);

            CenterPlayer();
        }

        private void CenterPlayer()
        {
            var cellPositionForPlayer = _tilemap.WorldToCell(transform.position);
            var cellCenterForPlayer = _tilemap.GetCellCenterWorld(cellPositionForPlayer);
            transform.position = cellCenterForPlayer;
        }

        private void FlipSprite(Vector2 value)
        {
            switch (value.x)
            {
                case > 0:
                    transform.localScale = new Vector3(1, 1, 1);
                    break;
                case < 0:
                    transform.localScale = new Vector3(-1, 1, 1);
                    break;
            }
        }
    }
}
