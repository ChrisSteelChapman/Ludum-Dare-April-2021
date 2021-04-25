using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    public GameObject barricade;
    public float buildTimer = 0.0f;
    private float buildTimerMax = 10.0f;
    public int stationType = 0; //0 for Barricade Station, 1 for Arrow Fletchery, 2 for Grindstone
    public Transform barricadeSpawnPoint;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void IncrementBuildTimer()
    {
        buildTimer += Time.deltaTime;

        if (buildTimer >= buildTimerMax)
        {
            //Reset Timer then Spawn new Barricade
            buildTimer = 0.0f;

            switch (stationType)
            {
                case 0:
                    Instantiate(barricade, barricadeSpawnPoint.position, barricadeSpawnPoint.rotation);
                    break;
                case 1:
                    player.GetComponent<PlayerAttack>().boltsRemaining += 15;
                    break;
                case 2:
                    player.GetComponent<PlayerAttack>().knifeDurability += 10;
                    break;
                case 3:
                    player.GetComponent<PlayerDamageable>().currentHealth += 10;
                    break;
                case 4:
                    player.GetComponent<CorruptionTracker>().currentCorruption += 10;
                    break;
                default:
                    break;

            }
        }
    }
}
