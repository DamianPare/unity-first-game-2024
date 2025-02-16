using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject[] Enemies;
    public float spawnInterval; // delay between spawning targets
    public Vector2 gridSize;
    private int spawned = 0;
    public int spawnLimit = 0;
    public GameObject spikeParent;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval); // spawns targets with delay
    }

    void SpawnEnemy()
    {
        {
            if(spawned <= spawnLimit)
            {
                int randomIndex = Random.Range(0, Enemies.Length);
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-18, 10), 0, Random.Range(18, 60));
                GameObject newSpike = Instantiate(Enemies[randomIndex], randomSpawnPosition, Quaternion.identity);
                newSpike.transform.parent = spikeParent.transform;
                spawned++;
            }
        }
    }
}
