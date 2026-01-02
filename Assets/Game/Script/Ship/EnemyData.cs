using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship
{
    [CreateAssetMenu]
    public class EnemyData : ScriptableObject
    {
        public string enemyName;
        public GameObject prefab;
        public GameObject bulletPrefab;
        public int maxHp;
        public float moveSpeed;
        public float attackSpeed;
   
    public EnemyData Clone()
    {
        return Instantiate(this);
    }

    }
}
