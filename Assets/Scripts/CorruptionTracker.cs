using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionTracker : MonoBehaviour
{
    public int currentCorruption = 0;
    public PlayerAttack playerAttack;

    private void Update()
    {
        if (currentCorruption > 19)
        {
            playerAttack.meleeDamage = 20;
        }
        if (currentCorruption > 31)
        {
            playerAttack.boltDamage = 20;
        }
        if (currentCorruption > 51)
        {
            // Make screen go wooby
        }
        if (currentCorruption > 71)
        {
            // Make screen Extremely Wooby
        }
        if (currentCorruption > 91)
        {
            // Full Monster Mode
        }
    }
}
