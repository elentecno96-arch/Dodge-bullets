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
        public GameObject Build(Vector2 pos)
        {
            EnemyData data = enemyData.Clone();

            data.moveSpeed *= difficultyMult;
            data.attackSpeed /= difficultyMult;

            GameObject enemyObj = GameObject.Instantiate(data.prefab, pos, Quaternion.identity);
            EnemyShip enemyShip = enemyObj.GetComponent<EnemyShip>();

            enemyShip.Setup(data);
            return enemyObj;
        }
    }
}
