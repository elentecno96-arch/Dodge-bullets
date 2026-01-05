using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Strategy.Move
{

    public class PlayerMove : MoveStrategy
    {
        public override void Move(Transform transform, float moveSpeed)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(h, v).normalized;
            transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
