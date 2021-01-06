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
    bool LightOn = true;
    public float timer = 0;
    public Behaviour FlashingScript;
    
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
            if (EventManager.BangingOnWindow)
            {
                light.range = 6;
                light.intensity = 6;
                light.color = Color.red;
                this.enabled = false;
                FlashingScript.enabled = true;
            }
            if (EventManager.InteractedWithBathroomHandle)
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
                        light.range = 4;
                    }
                }
            }

        }
    }
}
