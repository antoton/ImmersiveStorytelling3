using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithBathroomDoor : MonoBehaviour
{

    public void InteractWithBathroomDoorAfterMessage()
    {
        if(EventManager.PickedUpPhone3)
        {
            EventManager.InteractedWithBathroomHandle = true;
        }
        
    }
}
