using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableSound : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void EnableDisableAudioSource()
    {
        audioSource.mute = !audioSource.mute;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
