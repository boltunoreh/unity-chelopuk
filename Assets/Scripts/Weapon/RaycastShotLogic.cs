using Person;
using UnityEngine;

namespace Weapon
{
    public class RaycastShotLogic : IShotLogic
    {
        private const float LaserLength = 50f;

        public void Shot(GameObject ammo, Vector3 position, Vector3 difference, Transform shotDirection)
        {
            var web = Object.Instantiate(ammo, shotDirection.position, shotDirection.rotation);

            var layerMask = LayerMask.GetMask("Enemies", "Ground");

            //Get the first object hit by the ray
            var hit = Physics2D.Raycast(position, difference, LaserLength, layerMask);

            if (hit.collider != null)
            {
                var enemy = hit.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                    Debug.Log(enemy.name + ": " + enemy.health + " hp left");
                }
            }
        }
    }
}
