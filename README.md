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

A player instance for the VR-set can be instantiated by adding a Room-Scale XR-Rig to the scene, removing the original camera if necessary, as well as an XR-Interaction Manager.

For movement, it is necessary to add Locomotion system as a component to the XR-Rig. 

We opted for a Teleportation Provider and Snap Turn Provider. These need to be added as components to the XR-Rig.

When adding the Teleportation provider, add in the Locomotion Provider to its public System if necessary.

The same is true for Snap Turn Provider.

In the Snap Turn Provider, add the Left Hand and Right Hand Controllers found within the XR-Rig Game Object (possibly within the Camera Offset).

We chose to work with XR Ray interactors for interaction with the surroundings. 

To use this, add Device-Based Ray-interactors on both controllers. 

Put in the XR Interaction Manager from the scene into the XR Ray Interactor component on the controllers. 

# How to hand
For the VR hands i follow the tutorial on youtube from "Valem"

part 1: https://www.youtube.com/watch?v=gGYtahQjmWQ

part 2: https://www.youtube.com/watch?v=VdT0zMcggTQ




I didn't do everything, because he also adds the models of the controllers them self and some other functions.
I only add models for the hand and the animation for it. You can pay for hand models but there are some free models to.
The guy from the video gives you a ZIP white the model and the animation.

The first stap for the hands is the script. In the script "HandPresense" is the code for the hands.
The script search for the controller and adds hand model and the animation to the object. This script has also a UpdateHandAnimator and Update functions. The UpdateHandAnimator will change the value of 2 variables in the object HandAnimator, Grip and Trigger.

The next thing you need to do is the animation. In the ZIP that Zalem gives you are some animations. 1 for when you push the trigger and 1 for when you push the grip button. you need to create a New animation object and connect the animations with the wright values.
(Dont forget to do this twice, one for the right hand and one for the left hand )

When you did all of this you can put your sript on your XR hands (1 on the left hand and 1 on the right hand). No dragg and drop you hand model in the right variable. Do this also for the animation (left for the left controller, right for the right controller)

after this your done (check part 2 of youtube video for a beter explanation)