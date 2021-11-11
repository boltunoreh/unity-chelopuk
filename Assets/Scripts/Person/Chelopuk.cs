using UnityEngine;

namespace Person
{
    public class Chelopuk : AbstractCreature
    {
        private const float SpeedLimit = 10;
        private const float GroundRadius = 0.2f;

        public GameController gameController;
        public Transform groundCheck;

        public LayerMask whatIsGround;

        public float speed = 1;

        public float jumpHeight;
        private bool _isGrounded;

        private Vector2 _startPosition;

        // Start is called before the first frame update
        void Start()
        {
            _startPosition = transform.position;
        }

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, whatIsGround);

            if (transform.position.y < -15)
            {
                transform.position = _startPosition;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }

        // Update is called once per frame
        void Update()
        {
            var rigidbody2DComponent = GetComponent<Rigidbody2D>();
            if (Input.GetKey(KeyCode.D))
            {
                // transform.position += new Vector3(speed, 0, 0);
                Debug.Log(rigidbody2DComponent.velocity.x);
                // transform.position += new Vector3(-speed, 0, 0);
                if (rigidbody2DComponent.velocity.x < SpeedLimit)
                {
                    rigidbody2DComponent.AddForce(new Vector2(speed, 0));
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log(rigidbody2DComponent.velocity.x);
                // transform.position += new Vector3(-speed, 0, 0);
                if (rigidbody2DComponent.velocity.x > -SpeedLimit)
                {
                    rigidbody2DComponent.AddForce(new Vector2(-speed, 0));
                }
            }

            if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2DComponent.AddForce(new Vector2(0, jumpHeight));
            }
        }
        
        protected override void Die()
        {
            gameObject.SetActive(false);
            gameController.GameOver();
        }
    }
}