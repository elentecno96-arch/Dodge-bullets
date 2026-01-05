using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Pool
{
    public class EnemyPool : MonoBehaviour
    {
        public GameObject EnemyShip;
        public int poolsize;

        private Queue<GameObject> EnemyShipPool;
        private void Awake()
        {
            EnemyShipPool = new Queue<GameObject>();
            poolsize = 50;
            for (int i = 0; i < poolsize; i++)
            {
                CrateEnemy();
            }
        }
        GameObject CrateEnemy()
        {
            GameObject obj = Instantiate(EnemyShip, transform);
            obj.SetActive(false);
            EnemyShipPool.Enqueue(obj);
            return obj;
        }
        public GameObject GetEnemy()
        {
            if (EnemyShipPool.Count == 0)
            {
                return CrateEnemy();
            }
            GameObject obj = EnemyShipPool.Dequeue();
            return obj;
        }
        public void ReturnEnemy(GameObject obj)
        {
            obj.SetActive(false);
            EnemyShipPool.Enqueue(obj);
        }
    }
}
