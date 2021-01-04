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
    public bool SendDocuMessage = false;
    public Behaviour StartBuzzingScript;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if(EventManager.TurnedOfFaucet1 == true && SendDocuMessage == false)
        {
            SendDocuMessage = true;
            Material[] newMaterials = { PhoneScreen.materials[0], DocuMessage };
            PhoneScreen.materials = newMaterials;
            StartBuzzingScript.enabled = true;
        }
        if(EventManager.TurnedOfFaucet1 == false)
        {
            ResendMessage(60f);
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
