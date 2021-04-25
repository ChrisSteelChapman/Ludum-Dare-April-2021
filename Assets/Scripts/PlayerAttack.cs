using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int weaponType; // 0 for melee, 1 for ranged

    public GameObject[] weaponsArray;
    public int boltDamage = 10;
    public int boltsRemaining = 15;

    public Camera fpsCamera;

    public int meleeDamage = 10;
    public float meleeKnockBack = 10f;
    public int knifeDurability = 100;
    public float meleeRange = 5f;


    // Bitshift index of layer to get a bitmask.
    int layerMask = 1 << 10;

    private void Start()
    {
        // Invert Layermask.
        layerMask = ~layerMask;
    }

    public void Fire()
    {
        if (weaponType == 1 && boltsRemaining >= 0)
        {
            RaycastHit hit;
            Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit);
            Debug.Log(hit.transform);
            boltsRemaining--;

            Damageable target = hit.transform.GetComponent<Damageable>();
            if (target != null)
            {
                target.ChangeHealth(-boltDamage);
            }
        }
        else if (weaponType == 0)
        {
            Debug.Log("Stabbing");
            RaycastHit stab;
            Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out stab, meleeRange);
            Debug.Log(stab.transform);
            knifeDurability--;

            Damageable stabVictim = stab.transform.GetComponent<Damageable>();
            if (stabVictim != null)
            {
                stabVictim.ChangeHealth(-meleeDamage);
            }   
        }
    }
}

