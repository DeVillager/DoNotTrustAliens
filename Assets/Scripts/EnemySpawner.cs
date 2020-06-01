using System;
using UnityEngine;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Singleton<EnemySpawner>
{
    public GameObject[] enemies;
    public float spawnTime = 1;
    private float time;
    public float halfWidth = 7f;
    public float halfHeight = 4f;
    public float spawnTimeStart = 2f;
    public float spawnTimeEnd = 0.2f;


    void Update()
    {
        time += Time.deltaTime;
        spawnTime = (spawnTimeStart - spawnTimeEnd) / GameManager.Instance.gameTime * GameManager.Instance.time + spawnTimeEnd;
        if (time > spawnTime)
        {
            time = 0;
            Vector3 randPos = GetRandomPotation();
            int randInt = Random.Range(0, enemies.Length);
            Instantiate(enemies[randInt], randPos, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPotation()
    {
        return new Vector3(Random.Range(-halfWidth, halfWidth),Random.Range(-halfHeight, halfHeight));
    }
}
