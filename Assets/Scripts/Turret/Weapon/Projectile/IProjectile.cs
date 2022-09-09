
namespace Assets.Scripts.Turret.Weapon.Projectile
{
    public interface IProjectile
    {
        void TickApproaching();
        bool DidHit();
        void DestroyProjectile();
    }
}
