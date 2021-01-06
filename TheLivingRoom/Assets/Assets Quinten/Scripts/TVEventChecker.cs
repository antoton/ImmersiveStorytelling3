using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVEventChecker : MonoBehaviour
{
    public GameObject Television;

    //private GameObject waterDrop;
    //private Animator _animator;
    //private AudioSource _audioSource;
    private VideoPlayer video;
    private bool allreadyPlayed;
    private 

    // Start is called before the first frame update
    void Start()
    {
        video = Television.GetComponent<VideoPlayer>();

        //waterDrop = GameObject.FindWithTag("WaterDrop");
        //_animator = waterDrop.GetComponent<Animator>();
        //_audioSource = waterDrop.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.PickedUpPhone2 && EventManager.TurnedOfFaucet1 && EventManager.TurnedOnTelevision && !allreadyPlayed)
        {
            allreadyPlayed = true;
            video.Play();
        }                
    }

    public void startTVMethode()
    {
        if (EventManager.PickedUpPhone2 == true)
            EventManager.TurnedOnTelevision = true;
    }
}
