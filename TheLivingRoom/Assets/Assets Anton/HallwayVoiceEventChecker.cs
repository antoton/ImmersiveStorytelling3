using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayVoiceEventChecker : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject XRRig;
    bool playedOnce = false;
    public Behaviour WaitForDialogFinish;
    public Behaviour ChangeAudioProperties;

    // Update is called once per frame
    void Update()
    {
        if(EventManager.BangingOnWindow)
        {
            audioSource.loop = true;
            audioSource.spatialBlend = 0;
            ChangeAudioProperties.enabled = true;
            audioSource.Play();
            this.enabled = false;
        }
        if (EventManager.PickedUpPhone4 == true && XRRig.transform.position.x > -7.5 && XRRig.transform.position.z < 1.3 && !playedOnce)
        {
            Debug.Log("StartedPlaying");
            audioSource.Play();
            playedOnce = true;
            WaitForDialogFinish.enabled = true;
        }
    }
}
