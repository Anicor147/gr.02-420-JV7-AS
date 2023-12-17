using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace Script.Runtime.RuntimeScript
{
    public class DestroyWall : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        private Rigidbody2D _rigidbody2D;

        private int _numberOfCharge = 3;
        private const int _numberOfMaxCharge = 3;
        public bool ChargeIsMaxed { get; private set; }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void UpdateCharges()
        {
            _numberOfCharge = Math.Min(_numberOfCharge + 1, _numberOfMaxCharge);
            ChargeIsMaxed = _numberOfCharge == _numberOfMaxCharge;
            Debug.Log(_numberOfCharge);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("DestructiveWall") && _numberOfCharge > 0)
            {
                var hitPosition = Vector3.zero;
                foreach (var hit in other.contacts)
                {
                    hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                    hitPosition.y = hit.point.y - 0.02f * hit.normal.y;
                    var cellPositionForPlayer = _tilemap.WorldToCell(hitPosition);
                    var cellCenterForPlayer = _tilemap.GetCellCenterWorld(cellPositionForPlayer);
                    _tilemap.SetTile(_tilemap.WorldToCell(hitPosition), null);
                    _rigidbody2D.MovePosition(cellCenterForPlayer);
                    _numberOfCharge--;
                    Debug.Log(_numberOfCharge);
                    ChargeIsMaxed = false;
                    break;
                }
            }
        }
    }
}
