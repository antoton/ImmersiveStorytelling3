using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneEventChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Phone;
    public Renderer PhoneScreen;
    public Material DocuMessage;
    public Material BathroomMessage;
    public bool SentDocuMessage = false;
    bool SentBathroomMessage = false;
    bool WaitForBathroomMessage = false;
    public Behaviour StartBuzzingScript;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if(EventManager.TurnedOfFaucet1 == true && SentDocuMessage == false)
        {
            SentDocuMessage = true;
            Material[] newMaterials = { PhoneScreen.materials[0], DocuMessage };
            PhoneScreen.materials = newMaterials;
            StartBuzzingScript.enabled = true;
        }
        if(EventManager.TurnedOfFaucet1 == false)
        {
            ResendMessage(60f);
        }
        if (EventManager.TurnedOnTelevision == true && WaitForBathroomMessage == false)
        {
            timer = 0;
            WaitForBathroomMessage = true;
        }
        if (WaitForBathroomMessage)
        {
            timer += Time.deltaTime;
            if (timer >= 60f)
            {
                SentBathroomMessage = true;
                WaitForBathroomMessage = false;
                Material[] newMaterials = { PhoneScreen.materials[0], BathroomMessage };
                PhoneScreen.materials = newMaterials;
                StartBuzzingScript.enabled = true;
            }
        }




    }


    void ResendMessage(float timeToResend)
    {
        timer += Time.deltaTime;
        if (timer >= timeToResend)
        {
            timer = 0;
            StartBuzzingScript.enabled = true;
        }
    }
}
