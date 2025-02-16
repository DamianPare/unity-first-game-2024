using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    public GameObject[] floorPrefabs; // floor prefabs
    public GameObject[] targetPrefabs; // target prefabs
    public Vector2 gridSize; // grid size
    public float spawnInterval; // delay between spawning targets
    public Vector3 gridOrigin = Vector3.zero; // origin for the grid
    public float gridSpacingOffset = 1f; // offset grid tiles
    private int spawned = 0;
    public int spawnLimit = 0;
    public GameObject targetParent;
    public GameObject gridParent;


    private void Start()
    {
        GenerateGrid();
        InvokeRepeating(nameof(SpawnRandomTarget), spawnInterval, spawnInterval); // spawns targets with delay
    }

    void GenerateGrid() // grid generation
    {
        for (int row = 0; row < gridSize.y; row++) // generates y tiles
        {
            for (int col = 0; col < gridSize.x; col++) // generates x tiles
            {
                Vector3 spawnPos = gridOrigin + new Vector3(col * gridSpacingOffset, 0, row * gridSpacingOffset); // tile positions
                GameObject floorPrefab = floorPrefabs[Random.Range(0, floorPrefabs.Length)]; // floortile prefabs
                GameObject newGrid = Instantiate(floorPrefab, spawnPos, Quaternion.identity); // spawns floor tile
                newGrid.transform.parent = gridParent.transform;
            }
        }
    }

    void SpawnRandomTarget() // target generation
    {
        {
            if(spawned <= spawnLimit)
            {
                int randomRow = Random.Range(0, (int)gridSize.y); // grid y
                int randomCol = Random.Range(0, (int)gridSize.x); // grid x
                Vector3 floorTilePos = gridOrigin + new Vector3(randomCol * gridSpacingOffset, 0, randomRow * gridSpacingOffset); // spawns on grid
                GameObject targetPrefab = targetPrefabs[Random.Range(0, targetPrefabs.Length)]; // prefabs for targets
                GameObject newTarget = Instantiate(targetPrefab, floorTilePos, Quaternion.identity); // spawns targets
                newTarget.transform.parent = targetParent.transform;
                spawned++;
            }
        }
    }
}
