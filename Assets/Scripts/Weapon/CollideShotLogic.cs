using Person;
using UnityEngine;

namespace Weapon
{
    public class CollideShotLogic : IShotLogic
    {

        public void Shot(GameObject ammo, Vector3 position, Vector3 difference, Transform shotDirection)
        {
            Object.Instantiate(ammo, shotDirection.position, shotDirection.rotation);
        }
    }
}
