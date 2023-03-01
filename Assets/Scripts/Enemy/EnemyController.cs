using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;

    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer< 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    void SpawnEnemy()
    {
        Vector3 pos = GenerateRandomPos();

        pos += player.transform.position;

        GameObject newEnemy= Instantiate(enemy);
        newEnemy.transform.position = pos;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }
    private Vector3 GenerateRandomPos()
    {
        Vector3 pos = new Vector3();

        float f=UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            pos.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            pos.y = spawnArea.y * f;
        }
        else
        {
            pos.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            pos.x = spawnArea.x * f;
        }
        pos.z = 0f;
        return pos;
    }
}
