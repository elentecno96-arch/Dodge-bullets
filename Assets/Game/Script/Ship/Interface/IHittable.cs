using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Interface
{
    public interface IHittable
    {
        void Hit(float damage);
    }
}
