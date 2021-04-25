using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable
{
    public HealthBar healthBar;
    public override void Die()
    {
        //End Game
        Debug.Log("Player Died.");
    }

    private void Update()
    {
        healthBar.healthSlider.value = currentHealth;
    }
}
