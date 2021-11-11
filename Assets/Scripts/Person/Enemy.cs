using UnityEngine;

namespace Person
{
    public class Enemy : AbstractCreature
    {
        public AudioSource damageAudio;

        public AudioSource deathAudio;

        public override void TakeDamage(int damage)
        {
            damageAudio.PlayOneShot(damageAudio.clip);

            base.TakeDamage(damage);
        }

        protected override void Die()
        {
            deathAudio.PlayOneShot(deathAudio.clip);

            Destroy(gameObject);
        }
    }
}