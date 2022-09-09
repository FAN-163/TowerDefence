﻿using Assets.Scripts.Enemy;
using Assets.Scripts.Utils.Pooling;
using UnityEngine;

namespace Assets.Scripts.Turret.Weapon.Projectile.Bullet
{
    [CreateAssetMenu(menuName = "Assets/Bullet Projectile Asset", fileName = "Bullet Projectile Asset")]
    public class BulletProjectileAsset : ProjectileAssetBase
    {
        [SerializeField] private BulletProjectile m_BulletPrefab;
       
        public float Speed;
        public float Damage;
         

        public override IProjectile CreateProjectile(Vector3 origin, Vector3 originForward, EnemyData enemyData)
        {
            BulletProjectile projectile = GameObjectPool.InstantiatePooled(m_BulletPrefab, origin, Quaternion.LookRotation(originForward, Vector3.up));
            projectile.SetAsset(this);
            return projectile;
        }
    }
}
