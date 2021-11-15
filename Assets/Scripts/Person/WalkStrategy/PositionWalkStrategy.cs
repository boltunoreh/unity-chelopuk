using UnityEngine;

namespace Person.WalkStrategy
{
    public class PositionWalkStrategy : IWalkStrategy
    {
        public void Walk(GameObject person, Vector2 direction, float speed, float speedLimit)
        {
            var directionSpeed = (direction == Vector2.left ? -speed : speed) / 100;

            person.transform.position += new Vector3(directionSpeed, 0, 0);
        }
    }
}