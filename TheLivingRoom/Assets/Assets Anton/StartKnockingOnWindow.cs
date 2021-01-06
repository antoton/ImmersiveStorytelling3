using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKnockingOnWindow : MonoBehaviour
{
    public void InteractWithWindow()
    {
        if(EventManager.PickedUpPhone5)
        {
            EventManager.BangingOnWindow = true;
        }
    }
}
