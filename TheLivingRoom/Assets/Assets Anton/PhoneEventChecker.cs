using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneEventChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Phone;
    public Renderer PhoneScreen;
    public Material FirstMessage;
    public Material DocuMessage;
    public Material BathroomMessage;
    public Material NeighboursMessage;
    public Material WindowMessage;

    public bool SentDocuMessage = false;
    bool firstMessageSet = false;
    bool SentBathroomMessage = false;
    bool WaitForBathroomMessage = false;
    bool SentNeighboursMessage = false;
    bool SentWindowMessage = false;

    public Behaviour StartBuzzingScript;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if(EventManager.FirstMessageSent == true && firstMessageSet == false)
        {
            firstMessageSet = true;
            Material[] newMaterials = { PhoneScreen.materials[0], FirstMessage };
            PhoneScreen.materials = newMaterials;
            StartBuzzingScript.enabled = true;
        }

        if(EventManager.TurnedOfFaucet1 == true && SentDocuMessage == false && firstMessageSet == true)
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
            timer = 30f;
            WaitForBathroomMessage = true;
        }
        if (WaitForBathroomMessage == true && SentBathroomMessage == false)
        {
            timer += Time.deltaTime;
            if (timer >= 100f)
            {
                SentBathroomMessage = true;
                WaitForBathroomMessage = false;
                Material[] newMaterials = { PhoneScreen.materials[0], BathroomMessage };
                PhoneScreen.materials = newMaterials;
                StartBuzzingScript.enabled = true;
            }
        }
        if (EventManager.InteractedWithBathroomHandle == true && SentNeighboursMessage == false)
        {
            SentNeighboursMessage = true;
            Material[] newMaterials = { PhoneScreen.materials[0], NeighboursMessage };
            PhoneScreen.materials = newMaterials;
            StartBuzzingScript.enabled = true;
        }
        if (EventManager.HeardNeighbours == true && SentWindowMessage == false)
        {
            SentWindowMessage = true;
            Material[] newMaterials = { PhoneScreen.materials[0], WindowMessage };
            PhoneScreen.materials = newMaterials;
            StartBuzzingScript.enabled = true;
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
