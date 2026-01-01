using Game.Ship.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    EnemyShip ship;

    private void Awake()
    {
        ship = GetComponentInParent<EnemyShip>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ship.target = other.transform;
            ship.ChangeState("Attack");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ship.target = null;
            GetComponent<Collider2D>().enabled = false;
            ship.ChangeState("Move");
        }
    }
}
