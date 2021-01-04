using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBuzzing : MonoBehaviour
{
    public GameObject Phone;
    public AudioSource audioSource;
    // Start is called before the first frame update
    public void DisableBuzz()
    {
        Behaviour bhv = (Behaviour)Phone.GetComponent("PhoneTimer");
        bhv.enabled = false;
        audioSource.Stop();
        CheckForEvents();
    }
    public void CheckForEvents()
    {
        if(EventManager.FirstMessageSent == true)
        {
            EventManager.PickedUpPhone1 = true;
        }
        if (EventManager.TurnedOfFaucet1 == true)
        {
            EventManager.PickedUpPhone2 = true;
        }
        if(EventManager.SentBathroomMessage == true)
        {
            EventManager.PickedUpPhone3 = true;
        }
        if(EventManager.InteractedWithBathroomHandle == true)
        {
            EventManager.PickedUpPhone4 = true;
        }
        if(EventManager.HeardNeighbours == true)
        {
            EventManager.PickedUpPhone5 = true;
        }
    }
}
