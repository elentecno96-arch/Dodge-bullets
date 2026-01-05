using Game.Ship.Enemy;
using Game.Ship.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Strategy.Attack
{
    public class SectorAttack : AttackStrategy
    {
        EnemyShip EnemyShip;
        public SectorAttack(EnemyShip ship)
        {
            this.EnemyShip = ship;
        }
        public override void Attack(Transform transform)
        {
            int bulletCount = 3;
            float spreadAngle = 30f;

            float startAngle = -spreadAngle / 2f;
            float angleStep = spreadAngle / (bulletCount - 1);

            for (int i = 0; i < bulletCount; i++)
            {
                float currentAngle = startAngle + (angleStep * i);
                Quaternion bulletRotation = transform.rotation * Quaternion.Euler(0, 0, currentAngle);
                PoolManager.Instance.bulletPool.GetBullet(transform.position, bulletRotation);
            }
        }
    }
}
