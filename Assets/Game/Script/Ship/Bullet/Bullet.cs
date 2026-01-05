using Game.Ship.Interface;
using Game.Ship.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        public float speed;
        [SerializeField]
        public float damage;
        [SerializeField]
        public float lifeTime;

        private Coroutine lifeRoutine;

        private void Start()
        {
            damage = 1;
            speed = 3;
            lifeTime = 3f;
            Setup(damage, speed);
        }
        void Update()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHittable hittable = collision.GetComponent<IHittable>();
            if (hittable != null)
            {
                hittable.Hit(damage);
                ReturnToPool();
                //PoolManager.Instance.bulletPool.ReturnBullet(gameObject);
                //Destroy(gameObject);
            }
        }
        public void Setup(float damage, float speed)
        {
            this.damage = damage;
            this.speed = speed;

            if (lifeRoutine != null)
                StopCoroutine(lifeRoutine);

            lifeRoutine = StartCoroutine(LifeTimer());
        }
        private IEnumerator LifeTimer()
        {
            yield return new WaitForSeconds(lifeTime);
            ReturnToPool();
        }
        private void ReturnToPool()
        {
            PoolManager.Instance.bulletPool.ReturnBullet(gameObject);
        }
    }
}
