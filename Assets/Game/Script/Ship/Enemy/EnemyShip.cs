using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship;

namespace Game.Ship.Enemy
{
    public class EnemyShip : Ship
    {
        EnemyStateMachine stateMachine;

        private void Start()
        {
            stateMachine = new EnemyStateMachine(this);
            stateMachine.AddState("Move", new AI.EnemyAttackState());
            stateMachine.AddState("Attack", new AI.EnemyDIeState());
            stateMachine.AddState("Die", new AI.EnemyDIeState());
        }
        private void Update()
        {
            stateMachine.UpdateState();
        }
    }
}

