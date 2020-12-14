using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchingOnOff : MonoBehaviour
{
    public bool IsActive = true;
    public Light light;
    public float DarkTimer = 30;
    public float FlashingTimer = 5;
    public float AmountFlashes = 5;
    bool LightOn = false;
    public float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        light.range = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            timer += Time.deltaTime;
            if (!LightOn)
            {
                if (timer >= DarkTimer)
                {
                    LightOn = true;
                    timer = 0;
                }
            }
            else
            {
                if (timer >= FlashingTimer)
                {
                    LightOn = false;
                    timer = 0;
                    light.range = 0;
                }
                else
                {
                    for (float i = 1; i <= AmountFlashes; i++)
                    {
                        if ((i-0.1f) < timer && timer < (i+0.1f))
                        {
                            light.range = 0;
                            Debug.Log("should be dark now");
                        }
                        else light.range = 4;
                    }
                }
            }

        }
    }
}
