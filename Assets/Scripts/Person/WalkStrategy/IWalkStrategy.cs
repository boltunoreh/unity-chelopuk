using UnityEngine;

namespace Person.WalkStrategy
{
    public interface IWalkStrategy
    {
        public void Walk(GameObject person, Vector2 direction, float speed, float speedLimit);
    }
}