using Game.Ship.Interface;
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

        void Start()
        {
            Destroy(gameObject, lifeTime);
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
                Destroy(gameObject);
            }
        }
        public void Setup(float damage, float speed)
        {
            this.damage = damage;
            this.speed = speed;
        }
    }
}
