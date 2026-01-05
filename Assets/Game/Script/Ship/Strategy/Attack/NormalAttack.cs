using Game.Ship.Bullet;
using Game.Ship.Enemy;
using Game.Ship.Manager;
using Game.Ship.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Strategy.Attack
{
    public class NormalAttack : AttackStrategy
    {
        EnemyShip EnemyShip;

        public NormalAttack(EnemyShip ship)
        {
            this.EnemyShip = ship;
        }
        public override void Attack(Transform transform)
        {
           //Object.Instantiate(EnemyShip.bulletPrefab, transform.position, transform.rotation);
            PoolManager.Instance.bulletPool.GetBullet(transform.position, transform.rotation);
            //Debug.Log(PoolManager.Instance);
            Debug.Log(PoolManager.Instance.bulletPool);
        }
    }
}
