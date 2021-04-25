using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleFlicker : MonoBehaviour
{
    public Light candleLight;

    private void Update()
    {
        candleLight.intensity = Mathf.Lerp(candleLight.intensity, Random.Range(0.1f, 1.0f), Time.deltaTime);
    }
}
