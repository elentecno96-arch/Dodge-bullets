using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship
{
    public abstract class DieStrategy
    {
        abstract public void Die(GameObject obj);
    }
}
