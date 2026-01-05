using Game.Ship.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship
{
    public class EnemyBuilder
    {
        EnemyData enemyData;
        float difficultyMult;

        public EnemyBuilder SetbaseData(EnemyData data)
        {
            enemyData = data;
            return this;
        }
        public EnemyBuilder SetDifficultyMult(float mult)
        {
            difficultyMult = mult;
            return this;
        }
        public GameObject Build(GameObject obj, Vector2 pos)
        {
            EnemyData data = enemyData.Clone();
            data.moveSpeed *= difficultyMult;
            data.attackSpeed /= difficultyMult;

            obj.transform.position = pos;
            obj.transform.rotation = Quaternion.identity;

            EnemyShip enemyShip = obj.GetComponent<EnemyShip>();
            enemyShip.Setup(data);

            obj.SetActive(true);
            return obj;
        }
    }
}
