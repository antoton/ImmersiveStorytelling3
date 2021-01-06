using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomNoiseEventChecker : MonoBehaviour
{
    public AudioSource audioSource;
    bool playedOnce = false;
    public Behaviour ChangeAudioProperties;
    // Update is called once per frame
    void Update()
    {
        if(EventManager.PickedUpPhone3 && !playedOnce)
        {
            audioSource.Play();
            playedOnce = true;
        }
        if(EventManager.BangingOnWindow)
        {
            ChangeAudioProperties.enabled = true;
            audioSource.Play();
            this.enabled = false;
        }
    }
}
