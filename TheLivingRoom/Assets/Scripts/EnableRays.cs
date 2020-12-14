using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

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
}
