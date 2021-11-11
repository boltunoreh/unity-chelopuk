using UnityEngine;

namespace Weapon.Ammo
{
    public abstract class AbstractWeb : MonoBehaviour
    {
        public float speed;
        public float destroyTime;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyWeb", destroyTime);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        void DestroyWeb()
        {
            Destroy(gameObject);
        }
    }
}
