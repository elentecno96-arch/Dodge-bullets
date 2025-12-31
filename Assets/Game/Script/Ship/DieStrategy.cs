using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship
{
    public abstract class DieStrategy : MonoBehaviour
    {
        abstract protected void Die();
    }
}
