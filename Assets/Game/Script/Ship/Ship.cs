using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship.Interface;
using Unity.VisualScripting;

namespace Game.Ship
{
    public abstract class Ship : MonoBehaviour, IHittable
    {
        public MoveStrategy moveStrategy;
        public AttackStrategy attackStrategy;

        [SerializeField]
        protected int hp;
        [SerializeField]
        protected float attackSpeed;
        [SerializeField]
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
        public int GetHp()
        {
            return hp;
        }
        public float GetMoveSpeed()
        {
            return moveSpeed;
        }
        public float GetAttackSpeed()
        {
            return attackSpeed;
        }
    }
}
