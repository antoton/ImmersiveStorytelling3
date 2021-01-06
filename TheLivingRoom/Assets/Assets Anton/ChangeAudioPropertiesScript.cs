using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudioPropertiesScript : MonoBehaviour
{
    public AudioSource audioSource;
    public bool mute = false;
    public bool loop = false;
    [Range(0, 1)]
    [Tooltip("Preferably the same as original")]
    public float Volume = 1;
    [Range(-3,3)]
    [Tooltip("to slow down or speed up / lower or heighten the pitch")]
    public float Pitch = 1;
    [Tooltip("0 is normal, -1 is left, 1 is right")]
    [Range(-1,1)]
    public float StereoPan = 0;
    [Tooltip("0 is 2D (it doesn't care where the player is), 1 is 3D (changes depending on direction and location of player)")]
    [Range(0,1)]
    public float SpatialBlend = 1;
    // Start is called before the first frame update
    void OnEnable()
    {
        audioSource.mute = mute;
        audioSource.loop = loop;
        audioSource.volume = Volume;
        audioSource.pitch = Pitch;
        audioSource.panStereo = StereoPan;
        audioSource.spatialBlend = SpatialBlend;
        this.enabled = false;
    }
}
