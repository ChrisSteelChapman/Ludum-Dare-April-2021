using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;

    public float moveSpeed;

    private void Start()
    {
        //I know, I know, "Find by Tag bad", we're Moving at Mach 10 here people, we don't have time for "good"
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        this.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10 * step);
        this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
