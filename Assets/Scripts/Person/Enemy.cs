namespace Person
{
    public class Enemy : AbstractCreature
    {
        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}