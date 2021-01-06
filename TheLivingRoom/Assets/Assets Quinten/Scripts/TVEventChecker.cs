using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVEventChecker : MonoBehaviour
{
    public GameObject Television;

    private VideoPlayer video;
    private bool allreadyPlayed;
    private 

    // Start is called before the first frame update
    void Start()
    {
        video = Television.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.PickedUpPhone2 && EventManager.TurnedOfFaucet1 && EventManager.TurnedOnTelevision && !allreadyPlayed)
        {
            allreadyPlayed = true;
            video.Play();
        }
        if (EventManager.BangingOnWindow)
        {
            video.Play();
        }
    }

    public void startTVMethode()
    {
        if (EventManager.PickedUpPhone2 == true)
            EventManager.TurnedOnTelevision = true;
    }
}
