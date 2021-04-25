using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable
{
    public override void Die()
    {
        //End Game
        Debug.Log("Player Died.");
    }
}
