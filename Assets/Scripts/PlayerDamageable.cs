using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageable : Damageable
{
    public HealthBar healthBar;
    public GameObject deathPanel;
    public override void Die()
    {
        //End Game
        Debug.Log("Player Died.");
        deathPanel.SetActive(true);
        this.transform.root.gameObject.GetComponent<PlayerController>().enabled = false;
    }

    private void Update()
    {
        healthBar.healthSlider.value = currentHealth;
    }
}
