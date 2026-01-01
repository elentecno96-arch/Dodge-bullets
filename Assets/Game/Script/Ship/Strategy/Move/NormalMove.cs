using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Strategy.Move
{
    public class NormalMove : MoveStrategy
    {
        public override void Move(Transform transform, float moveSpeed)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime, Space.Self);
        }
    }
}
