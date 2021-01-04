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
    }
}
