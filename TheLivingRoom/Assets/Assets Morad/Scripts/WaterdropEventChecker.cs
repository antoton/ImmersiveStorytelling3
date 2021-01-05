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
        if (EventManager.PickedUpPhone1 == true && EventManager.TurnedOfFaucet1 == true)
        {
            _audioSource.mute = true;
            waterDrop.gameObject.GetComponent<Animator>().enabled = false;
        }

        if (EventManager.SentBathroomMessage == true && EventManager.TurnedOfFaucet2 == true)
        {
            _audioSource.mute = true;
            waterDrop.gameObject.GetComponent<Animator>().enabled = true;
        }
        if (!startAnimation)
        {
            _audioSource.mute = true;
            //waterDrop.transform.position = new Vector3((float)-6.7308, (float)1.06548, (float)4.09794);
            waterDrop.gameObject.GetComponent<Animator>().enabled = false;
        }
    }

    public void disableDripping()
    {
        EventManager.TurnedOfFaucet1 = true;
    }
}
