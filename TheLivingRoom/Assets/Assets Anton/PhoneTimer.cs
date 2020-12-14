using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTimer : MonoBehaviour
{
    public bool TimerIsRunning;
    public float BuzzerTime = 3.45f;
    public float MuteTime = 10;
    public bool Buzzing;
    float timer = 0;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerIsRunning)
        {
            timer += Time.deltaTime;
            if (Buzzing)
            {
                if (timer >= BuzzerTime)
                {
                    Buzzing = false;
                    audioSource.Stop();
                    timer = 0;
                }
            }
            else
            {
                if (timer >= MuteTime)
                {
                    Buzzing = true;
                    timer = 0;
                    audioSource.Play();
                }
            }
        }
    }
}
