using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForDialogFinish : MonoBehaviour
{
    public float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 45f)
        {
            EventManager.HeardNeighbours = true;
            this.enabled = false;
        }
    }
}
