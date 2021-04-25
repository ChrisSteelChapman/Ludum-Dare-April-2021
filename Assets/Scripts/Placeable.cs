using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    // Temporarily parent object to player's "hold point"
    // Rotate forward vector of object to player's forward vector

    public void PickedUp(Transform holder)
    {
        this.transform.position = holder.position;
        this.transform.parent = holder;
    }

    // Unparent
    public void Released()
    {
        this.transform.parent = null;
    }
}
