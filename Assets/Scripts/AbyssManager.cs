using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssManager : MonoBehaviour
{
    //This script controls the Abyss Behaviour 
    private AbyssWaveSpawner waveSpawner;
    private int waveNumber = 0;

    public GameObject[] enemyPrefabs;
    List<GameObject> tempList = new List<GameObject>();

    private void Start()
    {
        waveSpawner = this.GetComponent<AbyssWaveSpawner>();
        StartCoroutine(WaveEnd());
    }
    //Spawn Coroutine
    IEnumerator WaveEnd()
    {
        while (true)
        {
            // Find is a big heavy operation, so we don't want to do it every frame.
            yield return new WaitForSeconds(1f);
            // If there aren't any enemies left in the scene, 
            if (GameObject.FindObjectsOfType<EnemyController>().Length < 1)
            {
                // Wait 30 seconds
                yield return new WaitForSeconds(1f);
                // Get the next Wave and Spawn it.
                waveNumber++;
                waveSpawner.SpawnWave(waveTypes(waveNumber));
            }
        }
    }

    private List<GameObject> waveTypes(int waveNum)
    {
        switch(waveNum)
        {
            case 1:
                tempList.Add(enemyPrefabs[0]);
                break;
            case 2:
                tempList.Add(enemyPrefabs[1]);
                break;
            case 3:
                tempList.Add(enemyPrefabs[2]);
                break;
            default:
                tempList.Add(enemyPrefabs[3]);
                break;
        }
        return tempList;
    }
}
