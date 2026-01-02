using Game.Ship.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager instance;

        [SerializeField]
        List<EnemyData> enemyDataList;
        [SerializeField]
        Transform[] SpawnPoints;

        [SerializeField]
        float spawninterval;
        [SerializeField]
        float spawntime;

        private void Start()
        {
            instance = this;
        }
        private void Update()
        {
            spawntime += Time.deltaTime;
            if (spawntime >= spawninterval)
            {
                SpawnRandomEnemy();
                spawntime = 0;
            }
        }
        public void SpawnRandomEnemy()
        {
            if (enemyDataList.Count == 0) return;

            int randomDataIndex = UnityEngine.Random.Range(0, enemyDataList.Count);
            int randomPointIndex = UnityEngine.Random.Range(0, SpawnPoints.Length);
            Vector2 spawnPosition = SpawnPoints[randomPointIndex].position;

            SpawnEnemy(enemyDataList[randomDataIndex], SpawnPoints[randomPointIndex].position);
        }

        public void SpawnEnemy(EnemyData data, Vector2 position)
        {
            float difficultyMult = 1.0f + (GameManager.instance.GetScore() / 1000.0f);
            
            new EnemyBuilder()
                .SetbaseData(data)
                .SetDifficultyMult(difficultyMult)
                .Build(position);
        }
    }
}
