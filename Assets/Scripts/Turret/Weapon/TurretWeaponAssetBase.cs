using UnityEngine;

namespace Assets.Scripts.Turret.Weapon
{
    public abstract class TurretWeaponAssetBase : ScriptableObject
    {
        public abstract ITurretWeapon GetWeapon(TurretView view);
    }
}
