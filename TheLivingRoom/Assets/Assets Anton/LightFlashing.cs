using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlashing : MonoBehaviour
{
    public Light light;
    public float timer;
    public bool LightOn = true;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            if (LightOn)
            {
                light.range = 0;
            }
            else
            {
                light.range = 6;
            }
            timer = 0;
            LightOn = !LightOn;
        }
    }
}
