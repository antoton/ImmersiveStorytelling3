using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    public GameObject MainLamp;
    public float timer = 0;

    float TimerLightOn = 10;
    float TimerFlash = 1;
    bool ligtOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (EventManager.FirstMessageSent)
        //{
        //    timer += 
        //}

        //code die ik niet begrijp maar het werkt perfect
        if (EventManager.BangingOnWindow)
        {
            timer += Time.deltaTime;
            if (ligtOn)
            {
                if (timer >= TimerLightOn)
                {
                    MainLamp.SetActive(false);
                    ligtOn = false;

                }
            }
            else
            {
                MainLamp.SetActive(true);
                ligtOn = true;
            }
        }
    }    
}
