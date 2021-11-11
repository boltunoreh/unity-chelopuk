using UnityEngine;

namespace Person
{
    public class Chelopuk : AbstractCreature
    {
        public GameController gameController;
        public Transform groundCheck;

        public LayerMask whatIsGround;

        public float speed;

        public float jumpHeight;
        private float _groundRadius = 0.2f;
        private bool _isGrounded = false;

        private Vector2 _startPosition;

        // Start is called before the first frame update
        void Start()
        {
            _startPosition = transform.position;
        }

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, whatIsGround);

            if (transform.position.y < -15)
            {
                transform.position = _startPosition;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                // transform.position += new Vector3((float) 0.01, 0, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
            }

            if (Input.GetKey(KeyCode.A))
            {
                // transform.position += new Vector3((float) -0.01, 0, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
            }

            if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight));
            }
        }

        protected override void Die()
        {
            gameObject.SetActive(false);
            gameController.GameOver();
        }
    }
}