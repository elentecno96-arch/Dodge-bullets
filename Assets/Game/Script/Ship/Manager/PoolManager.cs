using Game.Ship.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Manager
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance;
        public BulletPool bulletPool;
        public EnemyPool enemyPool;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
