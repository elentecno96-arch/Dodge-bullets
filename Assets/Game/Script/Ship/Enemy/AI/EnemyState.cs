using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship.Enemy;

namespace Game.Ship.Enemy.AI
{
    public abstract class EnemyState
    {
        public EnemyStateMachine stateMachine;
        public EnemyShip owner;

        public virtual void StartState()
        {

        }
        public abstract void UpdateState();
        public virtual void ExitState()
        {

        }
    }
}
