using UnityEngine;

namespace Person
{
   public abstract class AbstractCreature : MonoBehaviour
   {
       public int health = 100;
       
       public virtual void TakeDamage(int damage)
       {
           health -= damage;
   
           if (health <= 0)
           {
               Die();
           }
       }
   
       protected abstract void Die();
   } 
}
