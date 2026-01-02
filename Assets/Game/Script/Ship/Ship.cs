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
        protected int Maxhp;
        protected int currentHp;    
        [SerializeField]
        protected float attackSpeed;
        [SerializeField]
        protected float moveSpeed;

        protected bool isDead;
        private void Awake()
        {
            isDead = false;
            Init();
        }
        protected abstract void Init();
        void Die()
        {
            isDead = true;
            Destroy(gameObject);

        }
        public virtual void Setup(EnemyData data)
        {
            this.Maxhp = data.maxHp;
            this.currentHp = data.maxHp;
            this.moveSpeed = data.moveSpeed;
            this.attackSpeed = data.attackSpeed;
        }
        public void Hit(float damage)
        {
            if (isDead) return;

            currentHp -= (int)damage;

            if (currentHp <= 0)
            {
                Die();
            }
        }
        public int GetHp()
        {
            return currentHp;
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
