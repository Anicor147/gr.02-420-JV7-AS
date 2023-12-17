using UnityEngine;

namespace Script.Runtime.RuntimeScript
{
    public class PlayerMouvement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            switch (Input.inputString)
            {
                case "d":
                    _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.right);
                    break;
                case "a":
                    _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.left);
                    break;
                case "s":
                    _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.down);
                    break;
                case "w":
                    _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.up);
                    break;
            }
        }
    }
}