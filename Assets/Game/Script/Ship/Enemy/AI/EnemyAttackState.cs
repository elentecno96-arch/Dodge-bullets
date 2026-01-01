using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Enemy.AI
{
    public class EnemyAttackState : EnemyState
    {
        EnemyShip ship;

        public EnemyAttackState(EnemyShip ship)
        {
            this.ship = ship;
        }
        public override void StartState()
        {
            ship.StartCoroutine(AttackLoopCo());
        }
        public override void UpdateState()
        {
            if (ship.target == null)
                return;

            Vector3 dir = ship.target.position - ship.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            ship.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        public override void ExitState()
        {
            ship.transform.rotation = Quaternion.identity;
        }
        IEnumerator AttackLoopCo()
        {
            yield return new WaitForSeconds(ship.GetAttackSpeed());
            ship.attackStrategy?.Attack(ship.transform);
            yield return new WaitForSeconds(ship.GetAttackSpeed());
            ship.ChangeState("Move");
        }
    }
}
