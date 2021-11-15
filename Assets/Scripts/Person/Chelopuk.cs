using Person.WalkStrategy;
using UnityEngine;

namespace Person
{
    public class Chelopuk : AbstractCreature
    {
        // TODO move somewhere?
        public GameController gameController;

        private Vector2 _startPosition;

        public Chelopuk()
        {
            // TODO DI
            _walkStrategy = new RigidbodyAddForceWalkStrategy();
        }

        // Start is called before the first frame update
        void Start()
        {
            _startPosition = transform.position;
        }

        protected new void FixedUpdate()
        {
            base.FixedUpdate();

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
                Walk(Vector2.right);
            }

            if (Input.GetKey(KeyCode.A))
            {
                Walk(Vector2.left);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        protected override void Die()
        {
            gameObject.SetActive(false);
            gameController.GameOver();
        }
    }
}