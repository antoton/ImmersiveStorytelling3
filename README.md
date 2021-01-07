# ImmersiveStorytelling3
 
 Github repo voor Immersive Storytelling AP Hogeschool 2020-2021
 Unity 2019.4.14f1

# Installation guide

Pull the latest version of this project from github. Select Add in Unity hub and select TheLivingRoom subfolder.
Startup the project > Select Edit > Project build settings > Switch to android platform (no need to change default settings).

# Unity Installs
Make sure your Unity version has Android Build Support, with OpenJDK and Android SDK & NDK Tools

# Buildup
The Project is build with the help of the XR and XR-interaction plugins, as well as Oculus XR plugin. .
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
