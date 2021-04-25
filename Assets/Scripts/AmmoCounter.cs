using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public int ammo;
    public Text ammoCounter;

    private void Update()
    {
        if (ammoCounter != null)
        {
            ammoCounter.text = "Ammo Remaining: " + ammo.ToString();
        }
    }

    public void SetAmmo(int ammoIn)
    {
        ammo = ammoIn;
    }
}
