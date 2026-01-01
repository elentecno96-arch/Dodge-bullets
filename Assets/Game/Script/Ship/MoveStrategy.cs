using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship
{
    public abstract class MoveStrategy
    {
        public abstract void Move(Transform transform, float moveSpeed);
    }
}
