using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship
{
    public abstract class AttackStrategy
    {
        public abstract void Attack(Transform transform);
    }
}
