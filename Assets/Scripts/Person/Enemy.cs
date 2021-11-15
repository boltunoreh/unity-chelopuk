using System;
using Person.WalkStrategy;
using UnityEngine;
using Random = System.Random;

namespace Person
{
    public class Enemy : AbstractCreature
    {
        private const float WalkDistance = 2f;

        public AudioSource damageAudio;

        public AudioSource deathAudio;

        private Vector2 _direction;

        private Vector2 _startPosition;

        private Vector2 _previousPosition;

        public Enemy()
        {
            // TODO DI
            WalkStrategy = new PositionWalkStrategy();
        }

        private void Start()
        {
            SetStartDirectionAndPosition();
        }

        protected new void FixedUpdate()
        {
            base.FixedUpdate();

            if (IsFarFromHome())
            {
                _direction = SwitchDirection();
            }

            Walk(_direction);

            _previousPosition = transform.position;
        }

        public override void TakeDamage(int damage)
        {
            damageAudio.PlayOneShot(damageAudio.clip);

            base.TakeDamage(damage);
        }

        protected override void Die()
        {
            deathAudio.PlayOneShot(deathAudio.clip);

            Destroy(gameObject);
        }

        private void SetStartDirectionAndPosition()
        {
            Random random = new Random();
            int randomValue = random.Next(100);

            _direction = randomValue <= 50 ? Vector2.left : Vector2.right;
            _startPosition = transform.position;
            _previousPosition = _startPosition;

            Debug.Log(gameObject.name + ": dir - " + _direction + ", pos - " + _startPosition);
        }

        private bool IsFarFromHome()
        {
            // Debug.Log(gameObject.name + " current diff abs: " + Mathf.Abs(transform.position.x - _startPosition.x));
            // Debug.Log(gameObject.name + " prev diff abs: " + Mathf.Abs(_previousPosition.x - _startPosition.x));
            
            if (Mathf.Abs(transform.position.x - _startPosition.x) < Mathf.Abs(_previousPosition.x - _startPosition.x))
            {
                Debug.Log(gameObject.name + "goes home!");

                return false;
            }

            // Debug.Log(gameObject.name + " current X: " + transform.position.x);
            // Debug.Log(gameObject.name + " start X: " + _startPosition.x);
            // Debug.Log(gameObject.name + " difference X: " + (transform.position.x - _startPosition.x));
            // Debug.Log(gameObject.name + " difference Abs: " + (Mathf.Abs(transform.position.x - _startPosition.x)));
            // Debug.Log(gameObject.name + " walk dist: " + WalkDistance);
            // Debug.Log(gameObject.name + " isFar: " + (Mathf.Abs(transform.position.x - _startPosition.x) >= WalkDistance));
            return Mathf.Abs(transform.position.x - _startPosition.x) >= WalkDistance;
        }

        private Vector2 SwitchDirection()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return _direction == Vector2.left ? Vector2.right : Vector2.left;
        }
    }
}