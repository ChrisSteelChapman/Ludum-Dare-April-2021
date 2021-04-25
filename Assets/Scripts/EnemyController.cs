using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public float moveSpeed;
    public float jumpBackAmount;

    public int contactDamageAmount;
    public bool canDamage = true;

    private void Start()
    {
        // I know, I know, "Find by Tag bad", we're Moving at Mach 10 here people, we don't have time for "good"
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        this.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10 * step);
        this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    // When the hitbox trigger touches something, check if it's damageable & not friendly & apply damage.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Abomination")
        {
            return;
        }
        Damageable enemyHit = other.GetComponent<Damageable>();
        if (enemyHit != null && canDamage)
        {
            enemyHit.ChangeHealth(-contactDamageAmount);
            StartCoroutine("DamageCooldown");
        }
    }

    IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(2.5f);
        canDamage = true;
    }
}
