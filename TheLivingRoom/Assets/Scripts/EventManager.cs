using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

public static class EventManager
{
    #region GameFlags
    //bool Started = true
    public static bool PickedUpPhone1 = false; //True when read the Fix Faucet message
    public static bool TurnedOfFaucet1 = false; //True when turned the faucet of the first time
    public static bool PickedUpPhone2 = false; //True when read the See Documentary message
    public static bool TurnedOnTelevision = false; //True when the Documentary is turned on. Faucet needs to start leaking again. Silhouette in bathroom appears.
    public static bool InteractedWithBathroomHandle = false; //True when Interacted with bathroomhandle AFTER silhouette starts appearing
    public static bool PickedUpPhone3 = false; //True when the Check Neighbours/FrontDoor message is read. This + Playerlocation starts audio behind the door and next flag 
    public static bool HeardNeighbours = false; //True X seconds after the neighbour audio clip started playing. Triggers new phone message
    public static bool PickedUpPhone4 = false; //True after the Don't Get Your Feet Wet Message. Water starts leaking and glasses start appearing on the floor
    public static bool BangingOnWindow = false; //True after X seconds after PickedUpPhone4. Everything should start playing simultaniously and continuously now.

    //Always make sure that your script always checked if it has already run as well, to make sure it doesn't start looping for no reason. 
    #endregion

}
