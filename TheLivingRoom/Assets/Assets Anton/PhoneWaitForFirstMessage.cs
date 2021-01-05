using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneWaitForFirstMessage : MonoBehaviour
{
    public bool DontWait = false;
    public float WaitTime = 60f;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        if (DontWait == true)
        {
            EventManager.FirstMessageSent = true;
            this.enabled = false;
        }
        
        if (EventManager.FirstMessageSent == false)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= WaitTime)
            {
                EventManager.FirstMessageSent = true;
                this.enabled = false;
            }
        } 
    }
}
