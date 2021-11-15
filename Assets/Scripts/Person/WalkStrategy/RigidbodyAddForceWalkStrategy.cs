using UnityEngine;

namespace Person.WalkStrategy
{
    public class RigidbodyAddForceWalkStrategy : IWalkStrategy
    {
        public void Walk(GameObject person, Vector2 direction, float speed, float speedLimit)
        {
            var directionSpeed = direction == Vector2.left ? -speed : speed;

            var rigidbody2DComponent = person.GetComponent<Rigidbody2D>();

            if (rigidbody2DComponent.velocity.x < speedLimit)
            {
                Debug.Log(person.name + " GOOO: " + directionSpeed);

                rigidbody2DComponent.AddForce(new Vector2(directionSpeed, 0));
            }
        }
    }
}