using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship.Enemy.AI;
using Unity.VisualScripting;

namespace Game.Ship.Enemy
{
    public class EnemyStateMachine
    {
        protected EnemyShip owner;
        protected EnemyState currentState;
        Dictionary<string, EnemyState> stateDic;

        public EnemyStateMachine(EnemyShip owner)
        {
            stateDic = new Dictionary<string, EnemyState>();
            this.owner = owner;
        }
        public void AddState(string name, EnemyState state)
        {
            state.stateMachine = this;
            state.owner = owner;
            stateDic.Add(name, state);
        }
        public void ChangeState(string name)
        {
            if (stateDic.ContainsKey(name) == false)
            {
                return;
            }
            if (currentState != null)
            {
                currentState.ExitState();
            }
            currentState = stateDic[name];
            currentState.StartState();
        }
        public void UpdateState()
        {
            currentState?.UpdateState();
            Debug.Log("현재 상태: " + currentState?.GetType().Name);
        }
    }
}
