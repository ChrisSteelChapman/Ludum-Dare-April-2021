using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    public GameObject barricade;
    public float buildTimer = 0.0f;
    private float buildTimerMax = 10.0f;

    public Transform barricadeSpawnPoint;
    public void IncrementBuildTimer()
    {
        buildTimer += Time.deltaTime;

        if (buildTimer >= buildTimerMax)
        {
            //Reset Timer then Spawn new Barricade
            buildTimer = 0.0f;
            Instantiate(barricade, barricadeSpawnPoint.position, barricadeSpawnPoint.rotation);
        }
    }
}
