# ImmersiveStorytelling3
 
 Github repo voor Immersive Storytelling AP Hogeschool 2020-2021
 Unity 2019.4.14f1

# Installation guide

Pull the latest version of this project from github. Select Add in Unity hub and select TheLivingRoom subfolder.
Startup the project > Select Edit > Project build settings > Switch to android platform (no need to change default settings).

# Unity Installs
Make sure your Unity version has Android Build Support, with OpenJDK and Android SDK & NDK Tools

# Buildup
The Project is build with the help of the XR and XR-interaction plugins, as well as Oculus XR plugin.

The can be installed via the Unity Package Manager (in the Advanced tab).

##XR-Rig
A player instance for the VR-set can be instantiated by adding a Room-Scale XR-Rig to the scene, removing the original camera if necessary, as well as an XR-Interaction Manager.

For movement, it is necessary to add Locomotion system as a component to the XR-Rig. 

We opted for a Teleportation Provider and Snap Turn Provider. These need to be added as components to the XR-Rig.

When adding the Teleportation provider, add in the Locomotion Provider to its public System if necessary.

The same is true for Snap Turn Provider.

In the Snap Turn Provider, add the Left Hand and Right Hand Controllers found within the XR-Rig Game Object (possibly within the Camera Offset).

We chose to work with XR Ray interactors for interaction with the surroundings. 

To use this, add Device-Based Ray-interactors on both controllers. 

Put in the XR Interaction Manager from the scene into the XR Ray Interactor component on the controllers. 

To disable the Line Visual, you can either disable the XR Interactor Line Visual, or make the Line Length 0. Other options are also available, such as with a script that enables rays on triggers. This did not work as we hoped, and thus we opted for changing the Line Length to 0.

    public class EnableRays : MonoBehaviour
    {
    public XRController controllerLeft;
    private XRInteractorLineVisual lineRenderer;
    private bool isEnabled = true;
    bool triggerValue;

    void Start()
    {
        lineRenderer = controllerLeft.GetComponent<XRInteractorLineVisual>();
    }
    // Update is called once per frame
    void Update()
    {
        //CheckForInput();

        if (controllerLeft.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            isEnabled = !isEnabled;
            onTrigger();
        }
    }
    private void onTrigger()
    {
        lineRenderer.enabled = isEnabled;

    }
    } }

## Teleportation
We are using the Teleportation Provider as stated above. 

For movement within the room, we used a Teleportation Area. This can be added to your scene via the GameObject -> XR -> Teleportation Area menu. 
Alternatively, add a teleportation area script to the object on which the player can move around. These should have a Mesh Collider. 

Add the XR interaction Manager from your scene to the Teleportation Area component. If wanted, you can add a Custom Reticle, appearing when the player casts his ray onto the floor with the controllers. We opted for a small sphere with a transparent material. 

## Interaction with environment
To make objects grab-able, add an XR Grab Interactable script to the object. Add in the XR Interaction Manager from the scene. 
If you want to offset the grab-point, add an empty object to your object and add in the necessary Transform information. Add the Grab-object to the Attach Transform in the XR Grab Interactable. 

If you want objects interactable, but not grab-able, add an XR Simple Interactable component to the object. 

For both types of object, you can make a script run the moment the player interacts with the object. If you want it the moment the player 'holds' an object, you can choose the 'On Select Entered' within the 'Interactable Events' tab of the XR Grab/Simple Interactable component. 

We have used this extensively for our story scaffolding, requiring players to interact in order to progress throughout the story.

## View Direction interaction
In order to actively start the experience, we ask the players to look up to the ceiling. This effectively starts the experience.
We achieved this with a simple script that checks the player's rotation, and moves the player the moment the condition is achieved. The necessary scripts are enabled and sounds are unmuted.
The player starts in an almost empty copy of the actual room, with no scripts or actively running components. The moment the player is moved to the actual room, the fake room gets destroyed.

    public class IntroScript : MonoBehaviour
    {
    public GameObject XRRig;
    public GameObject Phone;
    public GameObject Camera;
    public GameObject WaterDrop;

    void Update()
    {
        if(Camera.transform.rotation.eulerAngles.x <310 && Camera.transform.rotation.eulerAngles.x > 200)
        {
            XRRig.transform.position = XRRig.transform.position + new Vector3(10,0,0);
            Behaviour bhv = (Behaviour)Phone.GetComponent("PhoneWaitForFirstMessage");
            bhv.enabled = true;
            AudioSource AS = (AudioSource)WaterDrop.GetComponent<AudioSource>();
            AS.mute = false;
            Destroy(this.gameObject);
        }
    }
    }

# Event Manager
For the entire story sequence, we use an EventManager - a singleton - to follow-up each event with a new event that progresses the game. This uses multiple states and connects all the different elements the user experiences with eachother. These elements all use private booleans that have a default 'false'-value and only change to 'true' if the user has interacted with this element at the correct time and in a correct way.

    public static class EventManager
    {
    #region GameFlags
    //bool Started = true
    public static bool FirstMessageSent = false;
    public static bool PickedUpPhone1 = false; //True when read the Fix Faucet message
    public static bool TurnedOfFaucet1 = false; //True when turned the faucet of the first time
    public static bool PickedUpPhone2 = false; //True when read the See Documentary message
    public static bool TurnedOnTelevision = false; //True when the Documentary is turned on. Sends new message after X time.
    
    ETCETERA. Game version has more flags.
    //Always make sure that your script always checked if it has already run as well, to make sure it doesn't start looping for no reason. 
    #endregion
    }

## Waterdrop
For the waterdrop, we added an animation that loops and makes it look as if the faucet is leaking. With this a dripping sound is included. When the user selects the top bit of the water tap, both the animation as the sounds are stopped with the help of a script called waterDropEventChecker. This script checks if certain events have been triggered that need to be triggered and changes the state of the waterdrop if everything checks out. So the user gets the opportunity to stop the leaking faucet, but eventually, this isn't possible anymore to initiate the ending.

## Phone
The leading role during the entire game is assigned to the phone. This element is used as a story scaffolder and pushes the user forward and causes him/her to explore the room and to progress within the story. This element also uses the previous mentioned event manager and changes it's message based on the current state.
