using Person;
using UnityEngine;

namespace Weapon
{
    public class CollideShotLogic : IShotLogic
    {

        public void Shot(GameObject ammo, Vector3 position, Vector3 difference, Transform shotDirection)
        {
            // var web = Object.Instantiate(ammo, shotDirection.position, shotDirection.rotation);
            //
            // var layerMask = LayerMask.GetMask("Enemies", "Ground");
            //
            //
            //     var enemy = hit.transform.GetComponent<Enemy>();
            //
            //     if (enemy != null)
            //     {
            //         enemy.TakeDamage(1);
            //         Debug.Log(enemy.name + ": " + enemy.health + " hp left");
            //     }
        }
    }
}
