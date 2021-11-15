using Person.WalkStrategy;
using UnityEngine;

namespace Person
{
    public class Chelopuk : AbstractCreature
    {
        // TODO move somewhere?
        public GameController gameController;

        private Vector2 _startPosition;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _sprite;

        public Chelopuk()
        {
            // TODO DI
            WalkStrategy = new RigidbodyAddForceWalkStrategy();
        }

        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();

            _startPosition = transform.position;
        }

        protected new void FixedUpdate()
        {
            base.FixedUpdate();

            if (transform.position.y < -15)
            {
                transform.position = _startPosition;
                _rigidbody.velocity = Vector2.zero;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                Walk(Vector2.right);
                _sprite.flipX = false;

                if (IsGrounded)
                {
                    _animator.Play("player_run");
                }
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                Walk(Vector2.left);
                _sprite.flipX = true;

                if (IsGrounded)
                {
                    _animator.Play("player_run");
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            
            if (_rigidbody.velocity == Vector2.zero)
            {
                _animator.Play("player_idle");
            }

            if (!IsGrounded)
            {
                _animator.Play("player_jump");
            }
        }

        protected override void Die()
        {
            gameObject.SetActive(false);
            gameController.GameOver();
        }
    }
}