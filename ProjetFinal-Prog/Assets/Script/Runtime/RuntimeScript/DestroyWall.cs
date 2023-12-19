using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace Script.Runtime.RuntimeScript
{
    public class DestroyWall : MonoBehaviour
    {
        private Tilemap _tilemap;
        private Rigidbody2D _rigidbody2D;
        private int _numberOfCharge = 3;
        private const int _numberOfMaxCharge = 3;
        public bool ChargeIsMaxed { get; private set; }
        internal static event Action<int> OnChargeUpdate;

        public int NumberOfCharge
        {
            get => _numberOfCharge;
            set
            {
                _numberOfCharge = value;
                OnChargeUpdate?.Invoke(_numberOfCharge);
            }
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _tilemap = GameObject.FindWithTag("tilemap").GetComponent<Tilemap>();
        }

        public void UpdateCharges()
        {
            _numberOfCharge = Math.Min(_numberOfCharge + 1, _numberOfMaxCharge);
            ChargeIsMaxed = _numberOfCharge == _numberOfMaxCharge;
            OnChargeUpdate?.Invoke(_numberOfCharge);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("DestructiveWall") && _numberOfCharge > 0)
            {
                _numberOfCharge--;
                ChargeIsMaxed = false;
                var cellPositionForPlayer = _tilemap.WorldToCell(transform.position);
                var cellCenterForPlayer = _tilemap.GetCellCenterWorld(cellPositionForPlayer);
                _rigidbody2D.MovePosition(cellCenterForPlayer);
                OnChargeUpdate?.Invoke(_numberOfCharge);
                Destroy(other.gameObject);
            }
            else
            {
                var cellPositionForPlayer = _tilemap.WorldToCell(transform.position);
                var cellCenterForPlayer = _tilemap.GetCellCenterWorld(cellPositionForPlayer);
                _rigidbody2D.MovePosition(cellCenterForPlayer);
            }
        }
    }
}
