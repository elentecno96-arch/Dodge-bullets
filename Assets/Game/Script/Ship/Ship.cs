using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship.Interface;

namespace Game.Ship
{
    public abstract class Ship : MonoBehaviour, IHittable
    {
        protected MoveStrategy moveStrategy;
        protected AttackStrategy attackStrategy;

        protected int hp;
        protected float attackSpeed;
        protected float moveSpeed;

        protected bool isDead = false;

        private void Awake()
        {
            Init();
        }
        void Init()
        {
            isDead = false;
        }
        void Die()
        {
            isDead = true;
            Destroy(gameObject);

        }
        public void Hit(float damage)
        {
            if (isDead) return;

            hp -= (int)damage;

            if (hp <= 0)
            {
                Die();
            }
        }
    }
}
