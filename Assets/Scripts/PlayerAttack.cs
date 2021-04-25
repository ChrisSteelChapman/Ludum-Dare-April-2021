using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int weaponType; // 0 for melee, 1 for ranged

    public GameObject[] weaponsArray;
    public int boltDamage = 10;

    public Camera fpsCamera;

    public Collider meleeHitBox;
    public int meleeDamage = 10;
    public float meleeKnockBack = 10f;

    public Transform firePoint;

    private void Start()
    {
        meleeHitBox.enabled = false;
    }

    private void Update()
    {
        
    }

    public void Fire()
    {
        if (weaponType == 1) {
            RaycastHit hit;
            Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit);

            Damageable target = hit.transform.GetComponent<Damageable>();
            if (target != null)
            {
                target.ChangeHealth(-boltDamage);
            }
        }
        else
        {
            StartCoroutine("meleeAttack");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO: This is going off when enemies touch the player, not on swings.
        other.GetComponent<Damageable>().ChangeHealth(-meleeDamage);
    }

    IEnumerator meleeAttack()
    {
        meleeHitBox.enabled = true;
        yield return new WaitForSeconds(0.5f);
        meleeHitBox.enabled = false;
    }
}
