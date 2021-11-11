using UnityEngine;

namespace Weapon
{
    public interface IShotLogic
    {
        public void Shot(GameObject ammo, Vector3 position, Vector3 difference, Transform shotDirection);
    }
}