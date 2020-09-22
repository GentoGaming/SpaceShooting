namespace _Scripts.FG.NPC
{
    public interface IEntity
    {
        void TakeDamage(float damage);
        void Shoot();
        float Health { get;}
    }
}
