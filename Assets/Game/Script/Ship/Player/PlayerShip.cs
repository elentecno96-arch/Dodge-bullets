using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship;
using Game.Ship.Interface;

namespace Game.Ship.Player
{
    public class PlayerShip : Ship
    {
        protected override void Init()
        {
            moveStrategy = new Strategy.Move.PlayerMove();
            dieStrategy = new Strategy.Die.NormalDie();
        }
        private void Update()
        {
            if (isDead) return;
            moveStrategy?.Move(transform, moveSpeed);
        }
    }
}
