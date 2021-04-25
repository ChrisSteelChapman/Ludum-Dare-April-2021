using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int currentHealth = 10;
    public int maxHealth = 10;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int changeAmount)
    {
        currentHealth += changeAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
