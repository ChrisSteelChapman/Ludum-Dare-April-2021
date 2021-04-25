using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssWaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    public void SpawnWave(List<GameObject> spawnList)
    {
        foreach (GameObject gameObject in spawnList)
        {
            Instantiate(gameObject, spawnPoint.position, Quaternion.identity);
        }


    }
}
