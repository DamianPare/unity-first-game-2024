using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public GameObject[] orbPrefabs;
    public Transform[] spawnPoints;
    private int[] currentPositions;

    void Start()
    {
        currentPositions = new int[orbPrefabs.Length];
    }

    public void MoveOrbsToNewPositions()
    {
        // Move each orb to a new random spawn point
        for (int i = 0; i < orbPrefabs.Length; i++)
        {
            int newPosition = Random.Range(0, spawnPoints.Length);

            while(currentPositions.Contains(newPosition))
            {
                newPosition = Random.Range(0, spawnPoints.Length);
            }

            Transform spawnPoint = spawnPoints[newPosition];
            orbPrefabs[i].transform.position = spawnPoint.position;
            currentPositions[i] = newPosition;
        }
    }
}
