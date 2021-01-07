using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(-10,24,-4);
    public Transform TeleportGoal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        //other.transform.position = respawnPosition;
        other.transform.position = TeleportGoal.position;
    }
}
