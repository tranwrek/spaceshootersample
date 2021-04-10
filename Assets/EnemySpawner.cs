using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minimumSpawnTime = .1f;
    public float maximumSpawnTime = 2f;
    public float spawnCooldown = 0;

    public float minimumSpawnPosition;
    public float maximumSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown -= Time.deltaTime;
        if(spawnCooldown <= 0)
        {
            SpawnEnemy();
            spawnCooldown = Random.Range(minimumSpawnTime, maximumSpawnTime);
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = Random.Range(minimumSpawnPosition, maximumSpawnPosition);
        spawnPosition.y = this.transform.position.y;
        GameObject newInstance = Instantiate(enemyPrefab);
        newInstance.transform.position = spawnPosition;
    }
}
