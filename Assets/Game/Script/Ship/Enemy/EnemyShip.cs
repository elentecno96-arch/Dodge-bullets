using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship;
using Game.Ship.Strategy.Move;
using Game.Ship.Strategy.Attack;

namespace Game.Ship.Enemy
{
    public class EnemyShip : Ship
    {
        EnemyStateMachine stateMachine;
        public GameObject bulletPrefab;
        public Transform target;

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
        }
        public void ChangeState(string name)
        {
            stateMachine.ChangeState(name);
        }
    }
}

