using UnityEngine;

namespace GameDevLabirinth
{
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private float _moveY = 0f;
        public float _speed = 10f; //15 old
        public float BorderPosition = 5f;
        public float BorderPosition1 = 0f;
        float positionY;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

         private void FixedUpdate()
        {
            float positionY = _rigidbody2D.position.y + _moveY * _speed * Time.fixedDeltaTime;
            positionY = Mathf.Clamp(positionY, -BorderPosition1 , BorderPosition);
            _rigidbody2D.MovePosition(new Vector2( _rigidbody2D.position.x, positionY));
        }

        private void OnEnable()
        {
            PlayerInput.OnMove += Move;
        }

        private void OnDisable()
        {
            PlayerInput.OnMove -= Move;
        }

        private void Move(float moveY)
        {
            _moveY = moveY;
        }

        public void ResetPosition()
        {
            _rigidbody2D.position = new Vector2(_rigidbody2D.position.x, 0f);
        }
    }
}