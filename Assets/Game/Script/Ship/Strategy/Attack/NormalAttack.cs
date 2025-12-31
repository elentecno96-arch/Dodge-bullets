using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Strategy.Attack
{
    public class NormalAttack : AttackStrategy
    {
        public GameObject normalbulletPrefab;
        protected override void Attack(Transform transform, float damage, float attackSpeed)
        {
            Instantiate(normalbulletPrefab, transform.position, transform.rotation);
            //bullet.GetComponent<Bullet>().Setup(damage, attackSpeed);
        }
    }
}
