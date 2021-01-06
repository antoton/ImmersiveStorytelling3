using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdropEventChecker : MonoBehaviour
{
    public GameObject waterDrop;
    AudioSource _audioSource;
    Animator _animator;

    public bool startAnimation = true;

    // Start is called before the first frame update
    void Start()
    {
        _animator = waterDrop.GetComponent<Animator>();
        _audioSource = waterDrop.GetComponent<AudioSource>();
        Debug.Log(_animator);
        Debug.Log(_audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        //Afzetten kraan na eerste berichtje
        if (EventManager.PickedUpPhone1 == true && EventManager.TurnedOfFaucet1 == true)
        {
            _audioSource.mute = true;
            waterDrop.gameObject.GetComponent<Animator>().enabled = false;
            waterDrop.transform.position = new Vector3((float)-6.7308, (float)1.06548, (float)4.09794);
        }
        //Start kraan na docu
        if (EventManager.SentBathroomMessage && EventManager.TurnedOnTelevision)
        {
            _audioSource.mute = false;
            waterDrop.gameObject.GetComponent<Animator>().enabled = true;
        }
        //Afzetten kraan na 2de bericht
        if (EventManager.SentBathroomMessage == true && EventManager.TurnedOfFaucet2 == true && !EventManager.BangingOnWindow)
        {
            _audioSource.mute = true;
            waterDrop.gameObject.GetComponent<Animator>().enabled = false;
            waterDrop.transform.position = new Vector3((float)-6.7308, (float)1.06548, (float)4.09794);
        }
        //Als ze het een 2de keer hebben uitgezet gaat het terug aan
        if (EventManager.BangingOnWindow)
        {
            _audioSource.mute = false;
            waterDrop.gameObject.GetComponent<Animator>().enabled = true;
        }
    }

    public void disableDripping()
    {
        if (EventManager.PickedUpPhone1)
            EventManager.TurnedOfFaucet1 = true;
        if (EventManager.SentBathroomMessage)
            EventManager.TurnedOfFaucet2 = true;
    }
}
