using System;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Script.Runtime.RuntimeScript
{
    public class PlayerMouvement : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        private Rigidbody2D _rigidbody2D;
        internal static event Action<float> OnMovement;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            switch (Input.inputString)
            {
                case "d":
                    _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.right);
                    OnMovement?.Invoke(-1);
                    break;
                case "a":
                    _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.left);
                    OnMovement?.Invoke(-1);
                    break;
                case "s":
                    _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.down);
                    OnMovement?.Invoke(-1);
                    break;
                case "w":
                    _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.up);
                    OnMovement?.Invoke(-1);
                    break;
            }

            CenterPlayer();
        }

        private void CenterPlayer()
        {
            var cellPositionForPlayer = _tilemap.WorldToCell(transform.position);
            var cellCenterForPlayer = _tilemap.GetCellCenterWorld(cellPositionForPlayer);
            transform.position = cellCenterForPlayer;
        }
    }
}
