using Game.Ship;
using Game.Ship.Manager;
using Game.Ship.Strategy.Attack;
using Game.Ship.Strategy.Move;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Enemy
{
    public class EnemyShip : Ship
    {
        EnemyStateMachine stateMachine;
        public GameObject bulletPrefab;
        public Transform target;
        public float EnemyDisappearingTime = 12;
        bool isUpgradedAttack = false;

        private void OnEnable()
        {
            StartCoroutine(ReturnEnemySpawn(this.gameObject, EnemyDisappearingTime));
        }
        IEnumerator ReturnEnemySpawn(GameObject Enemy, float delay)
        {
            yield  return new WaitForSeconds(delay);
            PoolManager.Instance.enemyPool.ReturnEnemy(this.gameObject);
        }
        protected override void Init()
        {
            stateMachine = new EnemyStateMachine(this);
            stateMachine.AddState("Move", new AI.EnemyMoveState(this));
            stateMachine.AddState("Attack", new AI.EnemyAttackState(this));
            stateMachine.AddState("Die", new AI.EnemyDIeState());

            stateMachine.ChangeState("Move");

            moveStrategy = new NormalMove();
            attackStrategy = new NormalAttack(this);
            //stateMachine.ChangeState("Attack");
        }
        public override void Setup(EnemyData data)
        {
            base.Setup(data);
        }
        private void Update()
        {
            stateMachine.UpdateState();
            //Debug.Log("적 함선 업데이트 호출 중이요");
            if (!isUpgradedAttack && GameManager.instance.GetScore() >= 500f)
            {
                UpgradeAttackStrategy();
            }
        }
        public void ChangeState(string name)
        {
            stateMachine.ChangeState(name);
        }
        private void UpgradeAttackStrategy()
        {
            attackStrategy = new SectorAttack(this);
            // attackStrategy = new NormalAttack(this, 5, 45f); 
            isUpgradedAttack = true;
            Debug.Log($"{this.gameObject.name}: 점수 500 돌파! 부채꼴 공격으로 전환합니다.");
        }
    }
}

