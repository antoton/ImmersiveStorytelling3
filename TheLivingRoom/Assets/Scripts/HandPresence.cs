using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = true;
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handmodelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();        
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
        spawnedHandModel = Instantiate(handmodelPrefab, transform);
        handAnimator = spawnedHandModel.GetComponent<Animator>();
    }

    void UpdateHandAnimator()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            handAnimator.SetFloat("Trigger", triggerValue);
        else
            handAnimator.SetFloat("Trigger", 0);

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            handAnimator.SetFloat("Grip", gripValue);
        else
            handAnimator.SetFloat("Grip", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (showController)
        {
            spawnedHandModel.SetActive(true);
            UpdateHandAnimator();
        }
        else
        {
            spawnedHandModel.SetActive(false);
            
        }

        //if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        //    Debug.Log("pressing primary button");
        
        //if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        //    Debug.Log("trigger pressed " + triggerValue);
        
        //if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        //    Debug.Log("Primary touchpad " + primary2DAxisValue);
    }
}
