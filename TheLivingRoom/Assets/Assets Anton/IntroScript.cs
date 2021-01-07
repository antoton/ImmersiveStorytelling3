using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject XRRig;
    public GameObject Phone;
    public GameObject Camera;
    public GameObject WaterDrop;

    void Update()
    {
        if(Camera.transform.rotation.eulerAngles.x <300 && Camera.transform.rotation.eulerAngles.x > 200)
        {
            XRRig.transform.position = XRRig.transform.position + new Vector3(10,0,0);
            Behaviour bhv = (Behaviour)Phone.GetComponent("PhoneWaitForFirstMessage");
            bhv.enabled = true;
            AudioSource AS = (AudioSource)WaterDrop.GetComponent<AudioSource>();
            AS.mute = false;
            Destroy(this.gameObject);
        }
    }
}
