using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudioLoop : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void OnEnable()
    {
        audioSource.loop = true;
        audioSource.Play();
    }
}
