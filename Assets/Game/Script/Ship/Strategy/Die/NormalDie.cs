using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Strategy.Die
{
    public class NormalDie : DieStrategy
    {
        protected override void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
