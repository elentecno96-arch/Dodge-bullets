using Game.Ship.Strategy.Move;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Enemy.AI
{
    public class EnemyMoveState : EnemyState
    {
        EnemyShip ship;
        public EnemyMoveState(EnemyShip ship)
        {
            this.ship = ship;
        }

        public override void StartState()
        {
            
        }
        public override void UpdateState()
        {
            ship.moveStrategy?.Move(ship.transform, ship.GetMoveSpeed());
            //Debug.Log("나 이동 호출 중이요");
            ship.transform.rotation = Quaternion.Euler(0f,0f,180f);
        }
        public override void ExitState()
        {

        }
    }
}
