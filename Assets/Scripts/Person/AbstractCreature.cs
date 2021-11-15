using System.Collections.Specialized;
using Person.WalkStrategy;
using UnityEngine;
using UnityEngine.UI;

namespace Person
{
   public abstract class AbstractCreature : MonoBehaviour
   {
       private const float GroundRadius = 0.2f;

       public int health = 100;

       public float speedLimit = 10f;

       public float speed = 1;

       public float jumpHeight;

       public Transform groundCheck;

       protected bool IsGrounded;

       protected new IWalkStrategy WalkStrategy;

       protected void FixedUpdate()
       {
           int groundLayerMask = 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("Enemies");
           IsGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, groundLayerMask);
       }

       public virtual void TakeDamage(int damage)
       {
           health -= damage;
   
           if (health <= 0)
           {
               Die();
           }
       }

       protected void Walk(Vector2 direction)
       {
           WalkStrategy.Walk(gameObject, direction, speed, speedLimit);
       }
       
       protected void Jump()
       {
           Debug.Log("Jump! isGr: " + IsGrounded);
           if (IsGrounded)
           {
               GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight));
           }
       }

       protected abstract void Die();
   } 
}
