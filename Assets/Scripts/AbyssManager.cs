using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssManager : MonoBehaviour
{
    //This script controls the Abyss Behaviour 
    private AbyssWaveSpawner waveSpawner;
    private int waveNumber = 0;

    public GameObject[] enemyPrefabs;

    private void Start()
    {
        waveSpawner = this.GetComponent<AbyssWaveSpawner>();
        StartCoroutine(CallSpawn());
    }
    //Spawn Coroutine
    IEnumerator CallSpawn()
    {
        while (true)
        {
            Debug.Log("Spawning Wave " + waveNumber);
            waveSpawner.SpawnWave(waveTypes(waveNumber));
            waveNumber++;
            yield return new WaitForSeconds(1f);
        }
    }

    private List<GameObject> waveTypes(int waveNum)
    {
        List<GameObject> tempList = new List<GameObject>();
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
