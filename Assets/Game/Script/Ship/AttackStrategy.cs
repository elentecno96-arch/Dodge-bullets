using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship
{
    public abstract class AttackStrategy : MonoBehaviour
    {
        abstract protected void Attack(Transform transform, float damage, float attackSpeed);
    }
}
