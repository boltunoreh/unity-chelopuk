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

       public LayerMask groundLayerMask;

       private bool _isGrounded;

       protected new IWalkStrategy _walkStrategy;

       protected void FixedUpdate()
       {
           _isGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, groundLayerMask);
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
           _walkStrategy.Walk(gameObject, direction, speed, speedLimit);
       }
       
       protected void Jump()
       {
           Debug.Log("Jump! isGr: " + _isGrounded);
           if (_isGrounded)
           {
               GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight));
           }
       }

       protected abstract void Die();
   } 
}
