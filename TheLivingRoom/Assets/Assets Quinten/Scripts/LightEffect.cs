using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    public GameObject MainLamp;
    
    private float timer = 0;
    private float secondTimer = 0;
    private int timesLightFlashes = 3;
    private int timeslightHasFlash = 1;

    float TimerLightOn = 5f;
    float TimerFlash = .1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.FirstMessageSent)
        {
            timer += Time.deltaTime;
            if (timer >= TimerLightOn)
            {
                secondTimer += Time.deltaTime;
                if (MainLamp.activeSelf && (secondTimer >= TimerFlash))
                {
                    MainLamp.SetActive(false);
                    secondTimer = 0;
                }
                else if (!MainLamp.activeSelf && (secondTimer >= TimerFlash))
                {

                    MainLamp.SetActive(true);
                    timeslightHasFlash++;
                    secondTimer = 0;
                }
                if (timeslightHasFlash >= timesLightFlashes)
                {
                    timer = 0; 
                    timeslightHasFlash = 0;
                    TimerLightOn = Random.Range(2.0f, 10.0f);
                }
            }
        }
    }    
}
