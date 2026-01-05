using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Ship.Pool
{
    public class BulletPool : MonoBehaviour
    {
        public GameObject prefab;
        int poolSize;

        private Queue<GameObject> pool;

        private void Awake()
        {
            pool = new Queue<GameObject>();
            poolSize = 300;
            for (int i = 0; i < poolSize; i++)
            {
                CrateBullets();
            }
        }
        GameObject CrateBullets()
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
            return obj;
        }
        public void GetBullet(Vector2 pos, Quaternion rot)
        {
            GameObject obj = pool.Dequeue();
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.SetActive(true);
        }
        public void ReturnBullet(GameObject obj)
        {
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}
