using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship.Bullet;
using Game.Ship.Enemy;

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
           Object.Instantiate(EnemyShip.bulletPrefab, transform.position, transform.rotation);
        }
    }
}
