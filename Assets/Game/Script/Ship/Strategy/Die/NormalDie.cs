using Game.Ship.Manager;
using Game.Ship.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Strategy.Die
{
    public class NormalDie : DieStrategy
    {
        public override void Die(GameObject obj)
        {
            Object.Destroy(obj);
        }
    }
}
