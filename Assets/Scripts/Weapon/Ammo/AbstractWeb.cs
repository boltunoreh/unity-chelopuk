using System;
using Person;
using UnityEngine;

namespace Weapon.Ammo
{
    public abstract class AbstractWeb : MonoBehaviour
    {
        public float speed;
        public float destroyTime;
        public Rigidbody2D Rigidbody2D;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyWeb", destroyTime);
        }

        // Update is called once per frame
        void Update()
        {
            // transform.Translate(Vector2.right * speed * Time.deltaTime);
            Rigidbody2D.velocity = transform.right * speed;
        }

        // TODO move to collision shot logic?
        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            if (!hitInfo.CompareTag("Player"))
            {
                DestroyWeb();
            }
            
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
        }

        void DestroyWeb()
        {
            Destroy(gameObject);
        }
    }
}
